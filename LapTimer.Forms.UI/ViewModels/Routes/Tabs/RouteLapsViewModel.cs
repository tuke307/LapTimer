namespace LapTimer.Forms.UI.ViewModels.Routes
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System.Threading.Tasks;

    /// <summary>
    /// RouteLapsViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RouteLapsViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteLapsViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public RouteLapsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
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

        #endregion Methods

        #region Values

        public IMvxAsyncCommand SampleCommand { get; protected set; }

        #endregion Values
    }
}