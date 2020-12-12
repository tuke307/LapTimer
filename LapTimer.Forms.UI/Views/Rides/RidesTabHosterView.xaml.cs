namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RidesTabHosterView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxTabbedPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Root, Icon = "history", WrapInNavigationPage = true, NoHistory = false)]
    public partial class RidesTabHosterView : MvxTabbedPage<ViewModels.Rides.RidesTabHosterViewModel>
    {
        public RidesTabHosterView()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}