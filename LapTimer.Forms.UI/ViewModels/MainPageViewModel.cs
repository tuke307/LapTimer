namespace LapTimer.Forms.UI.ViewModels
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// MainViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class MainPageViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public MainPageViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
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
        }/// <summary>

         /// Shows the initial view models. </summary> <returns></returns>
        private Task ShowInitialViewModels()
        {
            var tasks = new List<Task>
            {
                this.NavigationService.Navigate<ViewModels.LapTimer.LapTimerTabViewModel>(),
                this.NavigationService.Navigate<ViewModels.Rides.RidesTabViewModel>(),
                this.NavigationService.Navigate<ViewModels.Routes.RoutesTabViewModel>()
            };
            return Task.WhenAll(tasks);
        }

        #endregion Methods

        #region Values

        private bool _firstTime = true;

        public IMvxAsyncCommand SampleCommand { get; protected set; }

        #endregion Values
    }
}