using Android.App;
using LapTimer.Core.Services;
using MvvmCross;
using MvvmCross.Platforms.Android;

namespace LapTimer.Forms.UI.Droid.Services
{
    public class CloseApplicationService : ICloseApplicationService
    {
        Activity Activity => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        public void CloseApplication()
        {
            Activity.FinishAffinity();
        }
    }
}