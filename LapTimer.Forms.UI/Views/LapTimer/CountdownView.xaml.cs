using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace LapTimer.Forms.UI.Views.LapTimer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountdownView : MvxContentPage
    {
        public CountdownView()
        {
            InitializeComponent();
        }
    }
}