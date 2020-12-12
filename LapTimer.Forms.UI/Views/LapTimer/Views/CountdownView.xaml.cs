namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// CountdownView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountdownView : MvxContentView<ViewModels.LapTimer.CountdownViewModel>
    {
        public CountdownView()
        {
            InitializeComponent();
        }
    }
}