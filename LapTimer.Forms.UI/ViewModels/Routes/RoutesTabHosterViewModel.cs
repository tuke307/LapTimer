namespace LapTimer.Forms.UI.ViewModels.Routes
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// RoutesTabHosterViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RoutesTabHosterViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutesTabHosterViewModel" />
        /// class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RoutesTabHosterViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
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

        /// <summary>
        /// Views the appearing.
        /// </summary>
        public override void ViewAppearing()
        {
            if (this._firstTime)
            {
                this.ShowInitialViewModels();
                this._firstTime = false;
            }
        }

        /// <summary>
        /// Views the disappeared.
        /// </summary>
        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
            this.NavigationService.Navigate<ViewModels.MainPageViewModel>();
            //this.NavigationService.Navigate<ViewModels.LapTimer.LapTimerTabViewModel>();
        }

        /// <summary>
        /// Shows the initial view models.
        /// </summary>
        /// <returns></returns>
        private Task ShowInitialViewModels()
        {
            var tasks = new List<Task>
            {
                this.NavigationService.Navigate<ViewModels.Routes.RouteLapsViewModel>(),
                this.NavigationService.Navigate<ViewModels.Routes.RouteTracksViewModel>(),
            };
            return Task.WhenAll(tasks);
        }

        #endregion Methods

        #region Values

        private bool _firstTime = true;

        #endregion Values
    }
}