namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
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
            this._locationService = locationService;
            this._messenger = messenger;
            this._token = messenger.Subscribe<MvxLocationMessage>(this.OnLocationUpdated);
            Loader = new TaskLoaderNotifier<SessionMapInfo>();
            SessionDisplayablePoint = new List<SessionDisplayablePoint>();
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

        private async Task<SessionMapInfo> LoadAsync()
        {
            SessionMapInfo mapInfo;

            mapInfo = new SessionMapInfo(
                SessionDisplayablePoint,
                new Position(10, 10),
                new Position(10, 10),
                0);

            return mapInfo;
        }

        private void OnLocationUpdated(MvxLocationMessage locationMessage)
        {
            //CurrentPosition = new Position(locationMessage.Latitude, locationMessage.Longitude);
        }

        #endregion Methods

        #region Values

        #region Commands

        public IMvxAsyncCommand OpenSettingsCommand { get; protected set; }

        public IMvxCommand SelectLapCommand { get; protected set; }

        public IMvxCommand SelectTrackCommand { get; protected set; }

        public IMvxAsyncCommand StartTimerCommand { get; protected set; }

        #endregion Commands

        private readonly ILocationService _locationService;

        private readonly IMvxMessenger _messenger;

        private readonly MvxSubscriptionToken _token;

        private Position _currentPosition;

        private TimeSpan _lapTime;

        private MvxLocationMessage _locationMessage;

        private List<SessionDisplayablePoint> _sessionDisplayablePoint;
        private double _speed;

        private TimeSpan _totalTime;

        public TimeSpan LapTime
        {
            get => this._lapTime;
            set => this.SetProperty(ref _lapTime, value);
        }

        public TaskLoaderNotifier<SessionMapInfo> Loader { get; }

        public List<SessionDisplayablePoint> SessionDisplayablePoint
        {
            get => this._sessionDisplayablePoint;
            set => this.SetProperty(ref _sessionDisplayablePoint, value);
        }

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