namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RidesTabView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxTabbedPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentation(Position = TabbedPosition.Tab, WrapInNavigationPage = true, NoHistory = false)]
    public partial class RidesTabHosterView : MvxContentPage<ViewModels.Rides.RidesTabHosterViewModel>
    {
        public RidesTabHosterView()
        {
            InitializeComponent();
        }
    }
}