namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RouteLapsView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Title = "Laps", WrapInNavigationPage = true, NoHistory = false/*, HostViewModelType = typeof(RoutesTabHosterView)*/)]
    public partial class RouteLapsView : MvxContentPage<ViewModels.Routes.RouteLapsViewModel>
    {
        //public const string _title = Functions.Functions.GetLocalisedRes(typeof(Resx.resources), "STR_TRACK");
        public RouteLapsView()
        {
            InitializeComponent();
        }
    }
}