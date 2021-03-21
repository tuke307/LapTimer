namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using Data.Enums;
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Models;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.Plugin.Messenger;
    using MvvmCross.ViewModels;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// DriveInViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class DriveInViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public DriveInViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMvxMessenger messenger, IRideService rideService)
            : base(logProvider, navigationService)
        {
            _rideService = rideService;
            _messenger = messenger;
            ResetCommand = new MvxCommand(ResetDriveIn);
            StartCommand = new MvxCommand(() => _messenger.Publish(new MvxTabIndexMessenger(this, 1)));
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

        private void ResetDriveIn()
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        #region Values

        #region Commands

        public IMvxCommand ResetCommand { get; protected set; }

        public IMvxCommand StartCommand { get; protected set; }

        #endregion Commands

        private readonly IMvxMessenger _messenger;
        private readonly IRideService _rideService;

        public bool LapSelected
        {
            get => _rideService.IsModeSelected(RouteMode.LapMode);
        }

        public bool TrackSelected
        {
            get => _rideService.IsModeSelected(RouteMode.TrackMode);
        }

        #endregion Values
    }
}