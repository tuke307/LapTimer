namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// StartingPositionView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class StartingPositionView : MvxContentView<ViewModels.LapTimer.StartingPositionViewModel>
    {
        public StartingPositionView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.LapTimer.StartingPositionViewModel))
            {
                if (MvvmCross.Mvx.IoCProvider.TryResolve<ViewModels.LapTimer.StartingPositionViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = MvvmCross.Mvx.IoCProvider.Resolve<MvvmCross.ViewModels.IMvxViewModelLoader>(); var
                request = new
                MvvmCross.ViewModels.MvxViewModelInstanceRequest(typeof(ViewModels.LapTimer.StartingPositionViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.LapTimer.StartingPositionViewModel;

                MvvmCross.Mvx.IoCProvider.RegisterSingleton<ViewModels.LapTimer.StartingPositionViewModel>(ViewModel);
            }
        }
    }
}