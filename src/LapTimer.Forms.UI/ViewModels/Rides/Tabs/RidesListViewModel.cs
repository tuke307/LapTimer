namespace LapTimer.Forms.UI.ViewModels.Rides
{
    using global::LapTimer.Core.Services;
    using Microsoft.Extensions.Logging;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using System.Threading.Tasks;

    /// <summary>
    /// RideTracksViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RidesListViewModel : RideTabViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RidesListViewModel" /> class.
        /// </summary>
        /// <param name="logFactory">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RidesListViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService, IDbActivityService dbactivityService, ITcxActivityService tcxActivityService)
            : base(logFactory, navigationService, dbactivityService, tcxActivityService)
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