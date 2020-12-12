namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// LapTimerView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LapTimerView : MvxContentView<ViewModels.LapTimer.LapTimerViewModel>
    {
        public LapTimerView()
        {
            InitializeComponent();
        }
    }
}