namespace LapTimer.Forms.UI.ViewModels.Routes
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// RoutesTabViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RoutesTabViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutesTabViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RoutesTabViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
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
            this.ShowInitialViewModels();
        }

        /// <summary>
        /// Shows the initial view models.
        /// </summary>
        /// <returns></returns>
        private Task ShowInitialViewModels()
        {
            var tasks = new List<Task>
            {
                this.NavigationService.Navigate<ViewModels.Routes.RoutesTabHosterViewModel>()
            };
            return Task.WhenAll(tasks);
        }

        #endregion Methods

        #region Values

        public IMvxAsyncCommand SampleCommand { get; protected set; }

        #endregion Values
    }
}