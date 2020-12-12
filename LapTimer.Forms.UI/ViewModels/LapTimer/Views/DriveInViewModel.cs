namespace LapTimer.Forms.UI.ViewModels.LapTimer
{
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
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
        public DriveInViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
            //ResetCommand = new MvxCommand(() => );
            //StartCommand = new MvxCommand(() => );
            //TrackSelected = ;
            //LapSelected = ;
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

        #region Commands

        public IMvxCommand ResetCommand { get; protected set; }

        public IMvxCommand StartCommand { get; protected set; }

        #endregion Commands

        private bool _lapSelected;
        private bool _trackSelected;

        public bool LapSelected
        {
            get => this._lapSelected;
            set => this.SetProperty(ref _lapSelected, value);
        }

        public bool TrackSelected
        {
            get => this._trackSelected;
            set => this.SetProperty(ref _trackSelected, value);
        }

        #endregion Values
    }
}