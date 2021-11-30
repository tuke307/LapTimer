namespace LapTimer.Forms.UI.Droid
{
    using LapTimer.Core.Services;
    using LapTimer.Forms.UI;
    using LapTimer.Forms.UI.Droid.Services;
    using Microsoft.Extensions.Logging;
    using MvvmCross;
    using MvvmCross.Forms.Platforms.Android.Core;
    using MvvmCross.IoC;
    using MvvmCross.Plugin;
    using Serilog;
    using Serilog.Extensions.Logging;

    public class Setup : MvxFormsAndroidSetup<MvxApp, FormsApp>
    {
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);

            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Messenger.Plugin>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Location.Fused.Plugin>();
        }

        /// <inheritdoc />
        protected override ILoggerFactory CreateLogFactory()
        {
            // serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                //.WriteTo.AndroidLog()
                //.WriteTo.File(GeneralSettings.LogFilePath)
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override void InitializeLastChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeLastChance(iocProvider);
            Mvx.IoCProvider.RegisterSingleton<IThemeService>(() => new ThemeService());
            Mvx.IoCProvider.RegisterSingleton<ICloseApplicationService>(() => new CloseApplicationService());
        }
    }
}