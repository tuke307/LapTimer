namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RideTracksView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    //[MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Title = "Tracks", WrapInNavigationPage = true, NoHistory = false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RideTracksView : MvxContentView<ViewModels.Rides.RideTracksViewModel>
    {
        public RideTracksView()
        {
            InitializeComponent();
        }
    }
}