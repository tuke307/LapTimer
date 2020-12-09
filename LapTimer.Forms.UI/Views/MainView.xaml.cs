namespace LapTimer.Forms.UI.Views
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// MainView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxTabbedPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Root)]
    public partial class MainView : MvxTabbedPage<ViewModels.MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}