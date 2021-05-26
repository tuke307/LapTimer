namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// LapTimerTabView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentation(Position = TabbedPosition.Tab, WrapInNavigationPage = true, NoHistory = false)]
    public partial class LapTimerTabView : MvxContentPage<ViewModels.LapTimer.LapTimerTabViewModel>
    {
        public LapTimerTabView()
        {
            InitializeComponent();
        }
    }
}