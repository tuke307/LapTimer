namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using Data.Models;
    using global::LapTimer.Core.Models;
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Functions;
    using global::LapTimer.Forms.UI.Models;
    using global::LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap;
    using Microsoft.Extensions.Logging;
    using MvvmCross;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.Plugin.Messenger;
    using MvvmCross.ViewModels;
    using Sharpnado.Presentation.Forms;
    using System;
    using System.Diagnostics;
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
        /// Initializes a new instance of the <see cref="RouteViewModel" /> class.
        /// </summary>
        /// <param name="logFactory">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RouteViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService, IRideService rideService, ILocationService locationService, IMvxMessenger messenger)
            : base(logFactory, navigationService)
        {
            this._rideService = rideService;
            this._locationService = locationService;
            this._messenger = messenger;
            this._token = messenger.Subscribe<MvxLocationMessage>(this.OnLocationUpdated);
            this._token = messenger.Subscribe<MvxTabIndexMessenger>(this.OnTabIndexUpdated);

            stopwatch = new Stopwatch();
            stopwatch.Reset();

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
            HandleAccuracy(locationMessage.MvxCoordinates.Accuracy);
            //CurrentPosition = new Position(locationMessage.Latitude, locationMessage.Longitude);

            TrackpointModel trackpoint = new TrackpointModel(locationMessage.MvxCoordinates);

            this._rideService.AddTrackpoint(trackpoint);
        }

        private void OnTabIndexUpdated(MvxTabIndexMessenger tabIndexMessage)
        {
            switch (tabIndexMessage.TabIndex)
            {
                case 0:
                    TimerNeeded = false;
                    break;

                case 1:
                    TimerNeeded = false;
                    break;

                case 2:
                    TimerNeeded = false;
                    break;

                case 3:
                    TimerNeeded = true;
                    StartTimer();
                    break;

                default:
                    break;
            }
        }

        private void StartTimer()
        {
            stopwatch.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                TotalTime = stopwatch.Elapsed;

                if (stopwatch.IsRunning)
                    return true;
                else
                    return false;
            });
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
        private bool _routeDrawing;
        private double _speed;
        private bool _timerNeeded;
        private TimeSpan _totalTime;
        private Stopwatch stopwatch;

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

        public bool RouteDrawing
        {
            get => this._routeDrawing;
            set => this.SetProperty(ref _routeDrawing, value);
        }

        public double Speed
        {
            get => this._speed;
            set => this.SetProperty(ref _speed, value);
        }

        public bool TimerNeeded
        {
            get => this._timerNeeded;
            set => this.SetProperty(ref _timerNeeded, value);
        }

        public TimeSpan TotalTime
        {
            get => this._totalTime;
            set => this.SetProperty(ref _totalTime, value);
        }

        #endregion Values
    }
}