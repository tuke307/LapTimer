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
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Icon = "history")]
    public partial class RidesTabView : MvxTabbedPage<ViewModels.Rides.RidesTabViewModel>
    {
        public RidesTabView()
        {
            InitializeComponent();
        }
    }
}