namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// DetailledRouteView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [MvxModalPresentationAttribute(WrapInNavigationPage = true, NoHistory = false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailledRouteView : MvxContentPage<ViewModels.Routes.DetailledRouteViewModel>
    {
        public DetailledRouteView()
        {
            InitializeComponent();
        }
    }
}