namespace LapTimer.Forms.UI.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.Content.Res;
    using Android.OS;
    using LapTimer.Core.Services;
    using MvvmCross;
    using MvvmCross.Forms.Platforms.Android.Views;
    using Sharpnado.Presentation.Forms.Droid;
    using System;

    [Activity(
       Label = "LapTimer",
       Icon = "@mipmap/icon",
       Theme = "@style/AppTheme",
       MainLauncher = false,
       ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
       LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        /// <summary>
        /// Called when [configuration changed].
        /// </summary>
        /// <param name="newConfig">The new configuration.</param>
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this.UpdateTheme(newConfig);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        /// <remarks>
        /// Portions of this page are modifications based on work created and shared by
        /// the <format type="text/html"><a
        /// href="https://developers.google.com/terms/site-policies" title="Android Open
        /// Source Project">Android Open Source Project</a></format> and used according to
        /// terms described in the  <format type="text/html"><a
        /// href="https://creativecommons.org/licenses/by/2.5/" title="Creative Commons
        /// 2.5 Attribution License">Creative Commons 2.5 Attribution
        /// License.</a></format>
        /// </remarks>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Essentials.Platform.Init(this, bundle);
            XF.Material.Droid.Material.Init(this, bundle);
            Xamarin.FormsGoogleMaps.Init(this, bundle);
            SharpnadoInitializer.Initialize(enableInternalDebugLogger: true);
        }

        /// <summary>
        /// Called when [resume].
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            UpdateTheme(Resources.Configuration);
        }

        /// <summary>
        /// Called when [start].
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            this.UpdateTheme(Resources.Configuration);
        }

        private void UpdateTheme(Configuration newConfig)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Froyo)
            {
                var uiModeFlags = newConfig.UiMode & UiMode.NightMask;
                switch (uiModeFlags)
                {
                    case UiMode.NightYes:
                        Mvx.IoCProvider.Resolve<IThemeService>().UpdateTheme(BaseTheme.Dark);
                        break;

                    case UiMode.NightNo:
                        Mvx.IoCProvider.Resolve<IThemeService>().UpdateTheme(BaseTheme.Light);
                        break;

                    default:
                        throw new NotSupportedException($"UiMode {uiModeFlags} not supported");
                }
            }
        }
    }
}