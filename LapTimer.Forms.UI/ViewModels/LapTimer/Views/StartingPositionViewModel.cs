namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Models;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.Plugin.Messenger;
    using MvvmCross.ViewModels;
    using System.Threading.Tasks;

    /// <summary>
    /// StartingPositionViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class StartingPositionViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public StartingPositionViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMvxMessenger messenger, IRideService rideService)
            : base(logProvider, navigationService)
        {
            _messenger = messenger;
            StartTimerCommand = new MvxCommand(() => _messenger.Publish(new MvxTabIndexMessenger(this, 2)));
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

        public IMvxCommand StartTimerCommand { get; protected set; }

        #endregion Commands

        private readonly IMvxMessenger _messenger;

        #endregion Values
    }
}