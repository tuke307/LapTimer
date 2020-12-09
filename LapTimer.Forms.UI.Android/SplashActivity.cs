namespace LapTimer.Forms.UI.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using LapTimer.Forms.UI;
    using MvvmCross.Forms.Platforms.Android.Views;
    using MvvmCross.Platforms.Android.Presenters.Attributes;
    using System.Threading.Tasks;

    /// <summary>
    /// SplashScreen.
    /// </summary>
    /// <seealso cref="MvvmCross.Platforms.Android.Views.MvxSplashScreenActivity" />
    [MvxActivityPresentation]
    [Activity(
         Label = "LapTimer",
         Icon = "@mipmap/logo",
         Theme = "@style/AppTheme.Splash",
         MainLauncher = true,
         NoHistory = true,
         ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : MvxFormsSplashScreenActivity<Setup, MvxApp, FormsApp>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen" /> class.
        /// </summary>
        public SplashActivity()
         : base(Resource.Drawable.SplashScreen)
        {
        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }
    }
}