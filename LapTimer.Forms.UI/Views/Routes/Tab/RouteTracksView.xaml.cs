namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RouteTracksView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Title = "Tracks")]
    public partial class RouteTracksView : MvxContentPage<ViewModels.Routes.RouteTracksViewModel>
    {
        //public const string _title = Functions.Functions.GetLocalisedRes(typeof(Resx.resources), "STR_TRACK");
        public RouteTracksView()
        {
            InitializeComponent();
        }
    }
}