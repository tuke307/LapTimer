namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using global::LapTimer.Forms.UI.Models;
    using global::LapTimer.Forms.UI.Views.LapTimer;
    using MvvmCross;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.Plugin.Messenger;
    using MvvmCross.ViewModels;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// LapTimerHosterViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class LapTimerHosterViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LapTimerTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public LapTimerHosterViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMvxMessenger messenger)
            : base(logProvider, navigationService)
        {
            CloseSiteCommand = new MvxAsyncCommand(() => this.NavigationService.Close(this));
            _token = messenger.Subscribe<MvxTabIndexMessenger>(OnTabIndexUpdated);
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

        public override void Prepare()
        {
            base.Prepare();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            _viewAppeared = true;
            FireTabViewAppeared();
        }

        protected void FireTabViewAppeared()
        {
            if (_viewAppeared)
            {
                switch (SelectedViewModelIndex)
                {
                    case 0:
                        Mvx.IoCProvider.Resolve<ViewModels.LapTimer.RouteDecisionViewModel>().ViewAppeared();
                        break;

                    case 1:
                        Mvx.IoCProvider.Resolve<ViewModels.LapTimer.DriveInViewModel>().ViewAppeared();
                        break;

                    case 2:
                        Mvx.IoCProvider.Resolve<ViewModels.LapTimer.StartingPositionViewModel>().ViewAppeared();
                        break;

                    case 3:
                        Mvx.IoCProvider.Resolve<ViewModels.LapTimer.CountdownViewModel>().ViewAppeared();
                        break;

                    case 4:
                        Mvx.IoCProvider.Resolve<ViewModels.LapTimer.LapTimerViewModel>().ViewAppeared();
                        break;

                    default:
                        break;
                }
            }
        }

        private void OnTabIndexUpdated(MvxTabIndexMessenger tabIndexMessage)
        {
            SelectedViewModelIndex = tabIndexMessage.TabIndex;
        }

        #endregion Methods

        #region Values

        #region Commands

        public MvxAsyncCommand CloseSiteCommand { get; protected set; }

        #endregion Commands

        private readonly MvxSubscriptionToken _token;
        private int _selectedViewModelIndex;
        private bool _viewAppeared;

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set
            {
                SetProperty(ref _selectedViewModelIndex, value);
                FireTabViewAppeared();
            }
        }

        #endregion Values
    }
}