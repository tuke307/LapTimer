using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace LapTimer.Forms.UI.Views.Rides
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RidesTabView : MvxTabbedPage
    {
        public RidesTabView()
        {
            InitializeComponent();
        }
    }
}