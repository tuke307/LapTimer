namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using global::LapTimer.Forms.UI.Services;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Threading.Tasks;

    /// <summary>
    /// LapTimerViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class LapTimerViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public LapTimerViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IRideService rideService)
            : base(logProvider, navigationService)
        {
            //ResetCommand = new MvxCommand(() => );
            //PlusCommand = new MvxCommand(() => );
            //StopCommand = new MvxCommand(() => );
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

        public IMvxCommand PlusCommand { get; protected set; }

        public IMvxCommand ResetCommand { get; protected set; }

        public IMvxCommand StopCommand { get; protected set; }

        #endregion Commands

        #endregion Values
    }
}