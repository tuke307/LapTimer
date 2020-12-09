namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// DetailledRideView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [MvxModalPresentationAttribute(WrapInNavigationPage = true, NoHistory = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailledRideView : MvxContentPage
    {
        public DetailledRideView()
        {
            InitializeComponent();
        }
    }
}