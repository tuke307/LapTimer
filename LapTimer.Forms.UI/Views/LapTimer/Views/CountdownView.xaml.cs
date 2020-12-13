namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// CountdownView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class CountdownView : MvxContentView<ViewModels.LapTimer.CountdownViewModel>
    {
        public CountdownView()
        {
            InitializeComponent();
        }
    }
}