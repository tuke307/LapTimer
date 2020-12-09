namespace LapTimer.Forms.UI.Droid
{
    using LapTimer.Forms.UI;
    using LapTimer.Forms.UI.Services;
    using MvvmCross;
    using MvvmCross.Forms.Platforms.Android.Core;
    using MvvmCross.Plugin;

    public class Setup : MvxFormsAndroidSetup<MvxApp, FormsApp>
    {
        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.IoCProvider.RegisterSingleton<IThemeService>(() => new ThemeService());
        }
    }
}