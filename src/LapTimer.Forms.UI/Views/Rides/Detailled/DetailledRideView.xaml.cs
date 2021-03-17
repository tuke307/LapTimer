namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// DetailledRideView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />

    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxModalPresentationAttribute(WrapInNavigationPage = true, NoHistory = false)]
    public partial class DetailledRideView : MvxContentPage<ViewModels.Rides.DetailledRideViewModel>
    {
        public DetailledRideView()
        {
            InitializeComponent();
        }
    }
}