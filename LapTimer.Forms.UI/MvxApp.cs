namespace LapTimer.Forms.UI
{
    using Data;
    using LapTimer.Core.Services;
    using LapTimer.Forms.UI.Services;
    using LapTimer.SkiaSharp.SkiaSharp;
    using MvvmCross;
    using MvvmCross.IoC;
    using MvvmCross.ViewModels;
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
            typeof(LocationService).Assembly.CreatableTypes()
               .EndingWith("Service")
               .AsInterfaces()
               .RegisterAsLazySingleton();

            // static registration => same instance
            Mvx.IoCProvider.RegisterSingleton(Plugin.Settings.CrossSettings.Current);
            Mvx.IoCProvider.RegisterSingleton<ITcxActivityService>(() => new TcxActivityService());
            Mvx.IoCProvider.RegisterSingleton<IDbActivityService>(() => new DbActivityService());
            Mvx.IoCProvider.RegisterSingleton<DatabaseContext>(() => new DatabaseContext());
            var context = Mvx.IoCProvider.Resolve<DatabaseContext>();
            Mvx.IoCProvider.RegisterSingleton<IRideService>(() => new RideService(context));

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