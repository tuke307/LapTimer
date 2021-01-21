namespace LapTimer.Forms.UI
{
    using LapTimer.Forms.UI.Services;
    using MvvmCross;
    using MvvmCross.IoC;
    using MvvmCross.ViewModels;
    using SkiaSharpnado.SkiaSharp;
    using System.Threading.Tasks;
    using Xamarin.Essentials;

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
            // init des location services.
            typeof(LapTimer.Forms.UI.Services.LocationService).Assembly.CreatableTypes()
               .EndingWith("Service")
               .AsInterfaces()
               .RegisterAsLazySingleton();

            // static registration => same instance
            Mvx.IoCProvider.RegisterSingleton(Plugin.Settings.CrossSettings.Current);
            Mvx.IoCProvider.RegisterSingleton<ITcxActivityService>(() => new TcxActivityService());
            Mvx.IoCProvider.RegisterSingleton<IDbActivityService>(() => new DbActivityService());
            Mvx.IoCProvider.RegisterSingleton<IRideService>(() => new RideService());

            // dynamic registration => new service on resolving
            Mvx.IoCProvider.RegisterType<ICountdownService>(() => new CountdownService());

            this.RegisterAppStart<ViewModels.MainPageViewModel>();

            SkiaHelper.Initialize((float)DeviceDisplay.MainDisplayInfo.Density);

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