namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RouteView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteView : MvxContentView<ViewModels.LapTimer.RouteViewModel>
    {
        public RouteView()
        {
            InitializeComponent();
        }
    }
}