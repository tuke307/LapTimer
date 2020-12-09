namespace LapTimer.Forms.UI
{
    using MvvmCross;
    using MvvmCross.ViewModels;
    using System.Threading.Tasks;

    /// <summary>
    /// MvxApp.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxApplication" />
    public class MvxApp : MvxApplication
    {
        /// <summary>
        /// Any initialization steps that can be done in the background.
        /// </summary>
        public override void Initialize()
        {
            this.RegisterAppStart<ViewModels.MainPageViewModel>();

            Mvx.IoCProvider.RegisterSingleton(Plugin.Settings.CrossSettings.Current);

            base.Initialize();
        }

        /// <summary>
        /// If the application is restarted (eg primary activity on Android can be
        /// restarted) this method will be called before Startup is called again.
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }

        /// <summary>
        /// Do any UI bound startup actions here.
        /// </summary>
        public override Task Startup()
        {
            return base.Startup();
        }
    }
}