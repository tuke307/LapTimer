namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross;
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using MvvmCross.ViewModels;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RouteView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class RouteView : MvxContentView<ViewModels.LapTimer.RouteViewModel>
    {
        public RouteView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.LapTimer.RouteViewModel))
            {
                if (MvvmCross.Mvx.IoCProvider.TryResolve<ViewModels.LapTimer.RouteViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = MvvmCross.Mvx.IoCProvider.Resolve<MvvmCross.ViewModels.IMvxViewModelLoader>(); var
                request = new
                MvvmCross.ViewModels.MvxViewModelInstanceRequest(typeof(ViewModels.LapTimer.RouteViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.LapTimer.RouteViewModel;

                MvvmCross.Mvx.IoCProvider.RegisterSingleton<ViewModels.LapTimer.RouteViewModel>(ViewModel);
            }
        }
    }
}