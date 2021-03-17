namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RoutesTabView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxTabbedPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Icon = "map_outline", WrapInNavigationPage = true, NoHistory = false)]
    public partial class RoutesTabHosterView : MvxContentPage<ViewModels.Routes.RoutesTabHosterViewModel>
    {
        public RoutesTabHosterView()
        {
            InitializeComponent();
        }
    }
}