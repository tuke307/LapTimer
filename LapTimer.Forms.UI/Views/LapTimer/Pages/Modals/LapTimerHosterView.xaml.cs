namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// LapTimerHosterView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [MvxModalPresentationAttribute(WrapInNavigationPage = true, NoHistory = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LapTimerHosterView : MvxContentPage<ViewModels.LapTimer.LapTimerHosterViewModel>
    {
        public LapTimerHosterView()
        {
            InitializeComponent();
        }
    }
}