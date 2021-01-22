namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using global::LapTimer.Forms.UI.Models;
    using global::LapTimer.Forms.UI.Services;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.Plugin.Messenger;
    using MvvmCross.ViewModels;
    using Sharpnado.Presentation.Forms;
    using SkiaSharpnado.Maps.Presentation.ViewModels.SessionMap;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms.GoogleMaps;

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
            Loader.Load(() => LoadAsync());
        }

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Initialisierung.</returns>
        public override Task Initialize()
        {
            return base.Initialize();
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

            mapInfo = SessionMapInfo.Create(
                null,
                null,
                1000,
                1000);

            return mapInfo;
        }

        private void OnLocationUpdated(MvxLocationMessage locationMessage)
        {
            CurrentPosition = new Position(locationMessage.Latitude, locationMessage.Longitude);
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

        private double _speed;

        private TimeSpan _totalTime;

        public Position CurrentPosition
        {
            get => this._currentPosition;
            set => this.SetProperty(ref _currentPosition, value);
        }

        public TimeSpan LapTime
        {
            get => this._lapTime;
            set => this.SetProperty(ref _lapTime, value);
        }

        public TaskLoaderNotifier<SessionMapInfo> Loader { get; }

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