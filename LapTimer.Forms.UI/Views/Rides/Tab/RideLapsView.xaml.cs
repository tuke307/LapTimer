namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RideLapsView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    //[MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Title = "Laps", WrapInNavigationPage = true, NoHistory = false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RideLapsView : MvxContentView<ViewModels.Rides.RideLapsViewModel>
    {
        //public const string _title = Functions.Functions.GetLocalisedRes(typeof(Resx.resources), "STR_TRACK");
        public RideLapsView()
        {
            InitializeComponent();
        }
    }
}