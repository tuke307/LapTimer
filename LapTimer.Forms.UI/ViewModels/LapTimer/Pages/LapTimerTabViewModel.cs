namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
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
        public LapTimerTabViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
            SelectLapCommand = new MvxCommand(() => this.LapSelected = true);
            SelectTrackCommand = new MvxCommand(() => this.TrackSelected = true);
            OpenSettingsCommand = new MvxAsyncCommand(() => this.NavigationService.Navigate<ViewModels.Settings.SettingsViewModel>());
            //StartTimerCommand = new MvxAsyncCommand();
            TrackSelected = true;

            //Routes
            //Route
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

        public IMvxAsyncCommand OpenSettingsCommand { get; protected set; }

        public IMvxCommand SelectLapCommand { get; protected set; }

        public IMvxCommand SelectTrackCommand { get; protected set; }

        public IMvxAsyncCommand StartTimerCommand { get; protected set; }

        #endregion Commands

        private bool _lapSelected;
        private bool _routesEnabled;
        private bool _trackSelected;

        public bool LapSelected
        {
            get => this._lapSelected;
            set
            {
                this.SetProperty(ref _lapSelected, value);

                if (TrackSelected == LapSelected)
                {
                    TrackSelected = !LapSelected;
                }
            }
        }

        public bool RoutesEnabled
        {
            get => this._routesEnabled;
            set => this.SetProperty(ref _routesEnabled, value);
        }

        public bool TrackSelected
        {
            get => this._trackSelected;
            set
            {
                this.SetProperty(ref _trackSelected, value);
                if (LapSelected == TrackSelected)
                {
                    LapSelected = !TrackSelected;
                }
            }
        }

        #endregion Values
    }
}