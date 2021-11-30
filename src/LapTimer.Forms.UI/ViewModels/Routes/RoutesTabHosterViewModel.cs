namespace LapTimer.Forms.UI.ViewModels.Routes
{
    using Microsoft.Extensions.Logging;
    using MvvmCross;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Threading.Tasks;

    /// <summary>
    /// RoutesTabViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RoutesTabHosterViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutesTabHosterViewModel" />
        /// class.
        /// </summary>
        /// <param name="logFactory">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RoutesTabHosterViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService)
            : base(logFactory, navigationService)
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

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            _viewAppeared = true;
            FireTabViewAppeared();
        }

        /// <summary>
        /// Checks the view apperead.
        /// </summary>
        protected void FireTabViewAppeared()
        {
            if (_viewAppeared)
            {
                Mvx.IoCProvider.Resolve<ViewModels.Routes.RoutesListViewModel>().ViewAppeared();
            }
        }

        #endregion Methods

        #region Values

        private int _selectedViewModelIndex;
        private bool _viewAppeared;

        public IMvxAsyncCommand SampleCommand { get; protected set; }

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