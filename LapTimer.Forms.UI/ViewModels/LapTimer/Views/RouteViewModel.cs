namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System;
    using System.Threading.Tasks;

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
        public RouteViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
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

        private TimeSpan _lapTime;
        private double _speed;
        private TimeSpan _totalTime;

        public TimeSpan LapTime
        {
            get => this._lapTime;
            set => this.SetProperty(ref _lapTime, value);
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