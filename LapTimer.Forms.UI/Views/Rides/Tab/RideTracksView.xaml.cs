namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RideTracksView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Title = "Tracks")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RideTracksView : MvxContentPage<ViewModels.Rides.RideTracksViewModel>
    {
        //public const string _title = Functions.Functions.GetLocalisedRes(typeof(Resx.resources), "STR_TRACK");
        public RideTracksView()
        {
            InitializeComponent();
        }
    }
}