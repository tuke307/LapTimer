namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// DriveInView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriveInView : MvxContentView<ViewModels.LapTimer.DriveInViewModel>
    {
        public DriveInView()
        {
            InitializeComponent();
        }
    }
}