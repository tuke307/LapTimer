namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RoutesTabView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxTabbedPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Icon = "map_outline")]
    public partial class RoutesTabView : MvxTabbedPage<ViewModels.Routes.RoutesTabViewModel>
    {
        public RoutesTabView()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}