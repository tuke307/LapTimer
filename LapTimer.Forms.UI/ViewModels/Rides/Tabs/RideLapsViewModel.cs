namespace LapTimer.Forms.UI.ViewModels.Rides
{
    using global::LapTimer.Core.Services;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using System.Threading.Tasks;

    /// <summary>
    /// RideLapsViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RideLapsViewModel : RideTabViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RideLapsViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="dbactivityService"></param>
        /// <param name="tcxActivityService"></param>
        public RideLapsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IDbActivityService dbactivityService, ITcxActivityService tcxActivityService)
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