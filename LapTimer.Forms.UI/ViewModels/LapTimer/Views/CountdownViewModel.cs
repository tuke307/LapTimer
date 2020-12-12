namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// CountdownViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class CountdownViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public CountdownViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
            //ResetCommand = new MvxCommand(() => );
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

        public IMvxCommand ResetCommand { get; protected set; }

        #endregion Commands

        private TimeSpan _timeSpanCountdown;

        public TimeSpan TimeSpanCountdown
        {
            get => this._timeSpanCountdown;
            set => this.SetProperty(ref _timeSpanCountdown, value);
        }

        #endregion Values
    }
}