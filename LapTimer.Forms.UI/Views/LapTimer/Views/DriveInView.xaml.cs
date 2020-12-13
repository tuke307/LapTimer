namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross;
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using MvvmCross.ViewModels;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// DriveInView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class DriveInView : MvxContentView<ViewModels.LapTimer.DriveInViewModel>
    {
        public DriveInView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.LapTimer.DriveInViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.LapTimer.DriveInViewModel>(out var driveInViewModel))
                {
                    ViewModel = driveInViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
                var request = new MvxViewModelInstanceRequest(typeof(ViewModels.LapTimer.DriveInViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.LapTimer.DriveInViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.LapTimer.DriveInViewModel>(ViewModel);
            }
        }
    }
}