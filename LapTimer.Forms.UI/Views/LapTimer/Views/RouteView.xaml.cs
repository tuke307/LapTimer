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
            InitializeComponent(); if (!(ViewModel is ViewModels.LapTimer.RouteViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.LapTimer.RouteViewModel>(out var driveInViewModel))
                {
                    ViewModel = driveInViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>();
                var request = new MvxViewModelInstanceRequest(typeof(ViewModels.LapTimer.RouteViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.LapTimer.RouteViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.LapTimer.RouteViewModel>(ViewModel);
            }
        }
    }
}