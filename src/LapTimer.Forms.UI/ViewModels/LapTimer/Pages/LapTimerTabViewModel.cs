namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using Data.Enums;
    using global::LapTimer.Core.Services;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Threading.Tasks;

    /// <summary>
    /// LapTimerTabViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class LapTimerTabViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public LapTimerTabViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IRideService rideService)
            : base(logProvider, navigationService)
        {
            _rideService = rideService;
            SelectLapCommand = new MvxCommand(HandleLapSelected);
            SelectTrackCommand = new MvxCommand(HandleTrackSelected);
            SelectFreeRideCommand = new MvxCommand(HandleFreeRideSelected);
            OpenSettingsCommand = new MvxAsyncCommand(() => this.NavigationService.Navigate<ViewModels.Settings.SettingsViewModel>());
            OpenLapTimerHosterCommand = new MvxAsyncCommand(() => this.NavigationService.Navigate<ViewModels.LapTimer.LapTimerHosterViewModel>());

            // voreingestellt
            this.FreeRideSelected = true;

            //Routes
            //Route
        }

        private void HandleFreeRideSelected()
        {
            this.LapSelected = false;
            this.TrackSelected = false;
            this.FreeRideSelected = true;
            _rideService.SetRideMode(RouteMode.FreeRideMode);
        }

        private void HandleLapSelected()
        {
            this.LapSelected = true;
            this.TrackSelected = false;
            this.FreeRideSelected = false;
            _rideService.SetRideMode(RouteMode.LapMode);
        }

        private void HandleTrackSelected()
        {
            this.LapSelected = false;
            this.TrackSelected = true;
            this.FreeRideSelected = false;
            _rideService.SetRideMode(RouteMode.TrackMode);
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

        #endregion Methods

        #region Values

        #region Commands

        private IRideService _rideService;

        public IMvxAsyncCommand OpenLapTimerHosterCommand { get; protected set; }

        public IMvxAsyncCommand OpenSettingsCommand { get; protected set; }

        public IMvxCommand SelectFreeRideCommand { get; protected set; }

        public IMvxCommand SelectLapCommand { get; protected set; }

        public IMvxCommand SelectTrackCommand { get; protected set; }

        #endregion Commands

        private bool _freeRideSelected;
        private bool _lapSelected;
        private bool _routesEnabled;
        private bool _trackSelected;

        public bool FreeRideSelected
        {
            get => this._freeRideSelected;
            protected set => this.SetProperty(ref _freeRideSelected, value);
        }

        public bool LapSelected
        {
            get => this._lapSelected;
            protected set => this.SetProperty(ref _lapSelected, value);
        }

        public bool RoutesEnabled
        {
            get => this._routesEnabled;
            set => this.SetProperty(ref _routesEnabled, value);
        }

        public bool TrackSelected
        {
            get => this._trackSelected;
            protected set => this.SetProperty(ref _trackSelected, value);
        }

        #endregion Values
    }
}