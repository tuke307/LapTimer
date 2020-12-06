using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace LapTimer.Forms.UI.Views.Routes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutesTabView : MvxTabbedPage
    {
        public RoutesTabView()
        {
            InitializeComponent();
        }
    }
}