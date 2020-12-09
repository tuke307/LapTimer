namespace LapTimer.Forms.UI.Views.Settings
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// SettingsView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [MvxModalPresentationAttribute(WrapInNavigationPage = true, NoHistory = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : MvxContentPage<ViewModels.Settings.SettingsViewModel>
    {
        public SettingsView()
        {
            InitializeComponent();
        }
    }
}