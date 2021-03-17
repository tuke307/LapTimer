namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// ResultView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [MvxModalPresentationAttribute(WrapInNavigationPage = true, NoHistory = false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultView : MvxContentPage<ViewModels.LapTimer.ResultViewModel>
    {
        public ResultView()
        {
            InitializeComponent();
        }
    }
}