﻿namespace LapTimer.Forms.UI.Droid
{
    using LapTimer.Forms.UI;
    using LapTimer.Forms.UI.Services;
    using MvvmCross;
    using MvvmCross.Forms.Platforms.Android.Core;
    using MvvmCross.Plugin;

    public class Setup : MvxFormsAndroidSetup<MvxApp, FormsApp>
    // No Splash Screen with this; MvxAndroidSetup<App>
    {
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);

            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.WebBrowser.Platforms.Android.Plugin>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Messenger.Plugin>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Location.Fused.Plugin>();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.IoCProvider.RegisterSingleton<IThemeService>(() => new ThemeService());
        }
    }
}