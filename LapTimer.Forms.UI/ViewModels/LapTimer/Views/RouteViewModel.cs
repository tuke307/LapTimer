namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using Data.Models;
    using global::LapTimer.Core.Models;
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Functions;
    using global::LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap;
    using MvvmCross;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.Plugin.Messenger;
    using MvvmCross.ViewModels;
    using Sharpnado.Presentation.Forms;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.GoogleMaps;
    using XF.Material.Forms.UI.Dialogs;

    /// <summary>
    /// RouteViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RouteViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RouteViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IRideService rideService, ILocationService locationService, IMvxMessenger messenger)
            : base(logProvider, navigationService)
        {
            this._rideService = rideService;
            this._locationService = locationService;
            this._messenger = messenger;
            this._token = messenger.Subscribe<MvxLocationMessage>(this.OnLocationUpdated);
            Loader = new TaskLoaderNotifier<SessionMap>();
        }

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Initialisierung.</returns>
        public override async Task Initialize()
        {
            await base.Initialize();

            // permissions
            PermissionStatus locationWhenInUse = await PermissionHelper.GetPermission<Permissions.LocationWhenInUse>().ConfigureAwait(true);

            if (locationWhenInUse != PermissionStatus.Granted || locationWhenInUse != PermissionStatus.Granted)
            {
                var dialog = await MaterialDialog.Instance.ConfirmAsync(message: "Check your permission settings",
                                   title: "Alert");

                if (dialog.HasValue)
                {
                    Mvx.IoCProvider.Resolve<ICloseApplicationService>().CloseApplication();
                }
            }

            Loader.Load(() => LoadAsync());
        }

        /// <summary>
        /// Prepares this instance. called after construction.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();
        }

        /// <summary>
        /// Behandelt die Signalstärke und ändert jenachdem das angezeigte Bild.
        /// 0-5 - sehr gut
        /// 6-15 - gut
        /// >= 16 - schlecht
        /// </summary>
        /// <param name="value">The value.</param>
        private void HandleAccuracy(double? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            // 0-5
            if (value.Value >= 0 && value.Value <= 5)
            {
                AccuracyImage = ImageSource.FromFile(signal_cellular_3);
            }
            // 6-15
            else if (value.Value >= 6 && value.Value <= 15)
            {
                AccuracyImage = ImageSource.FromFile(signal_cellular_2);
            }
            else if (value.Value >= 16)
            {
                AccuracyImage = ImageSource.FromFile(signal_cellular_1);
            }
        }

        private async Task<SessionMap> LoadAsync()
        {
            SessionMap mapInfo;

            mapInfo = new SessionMap();

            return mapInfo;
        }

        private void OnLocationUpdated(MvxLocationMessage locationMessage)
        {
            HandleAccuracy(locationMessage.Accuracy);
            //CurrentPosition = new Position(locationMessage.Latitude, locationMessage.Longitude);
            TrackpointModel trackpoint = new TrackpointModel();
            trackpoint.Altitude = locationMessage.Altitude;
            this._rideService.AddTrackpoint(trackpoint);
        }

        #endregion Methods

        #region Values

        #region Commands

        private readonly IRideService _rideService;

        public IMvxAsyncCommand OpenSettingsCommand { get; protected set; }

        public IMvxCommand SelectLapCommand { get; protected set; }

        public IMvxCommand SelectTrackCommand { get; protected set; }

        public IMvxAsyncCommand StartTimerCommand { get; protected set; }

        #endregion Commands

        private readonly ILocationService _locationService;
        private readonly IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;
        private readonly string signal_cellular_1 = "signal_cellular_1";

        private readonly string signal_cellular_2 = "signal_cellular_2";

        private readonly string signal_cellular_3 = "signal_cellular_3";
        private ImageSource _accuracyImage;
        private Position _currentPosition;

        private TimeSpan _lapTime;

        private MvxLocationMessage _locationMessage;

        private double _speed;

        private TimeSpan _totalTime;

        public ImageSource AccuracyImage
        {
            get => this._accuracyImage;
            set => this.SetProperty(ref _accuracyImage, value);
        }

        public TimeSpan LapTime
        {
            get => this._lapTime;
            set => this.SetProperty(ref _lapTime, value);
        }

        public TaskLoaderNotifier<SessionMap> Loader { get; }

        public double Speed
        {
            get => this._speed;
            set => this.SetProperty(ref _speed, value);
        }

        public TimeSpan TotalTime
        {
            get => this._totalTime;
            set => this.SetProperty(ref _totalTime, value);
        }

        #endregion Values
    }
}