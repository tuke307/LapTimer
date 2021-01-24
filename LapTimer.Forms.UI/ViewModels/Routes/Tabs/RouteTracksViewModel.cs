namespace LapTimer.Forms.UI.ViewModels.Routes
{
    using global::LapTimer.Core.Services;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using System.Threading.Tasks;

    /// <summary>
    /// RouteTracksViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RouteTracksViewModel : RouteTabViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteTracksViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RouteTracksViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IDbActivityService dbactivityService, ITcxActivityService tcxActivityService)
            : base(logProvider, navigationService, dbactivityService, tcxActivityService)
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
        /// Views the appeared.
        /// </summary>
        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }

        #endregion Methods
    }
}