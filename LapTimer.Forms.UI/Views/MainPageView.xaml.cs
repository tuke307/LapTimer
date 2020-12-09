namespace LapTimer.Forms.UI.Views
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// MainPageView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxTabbedPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Root)]
    public partial class MainPageView : MvxTabbedPage<ViewModels.MainPageViewModel>
    {
        public MainPageView()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}