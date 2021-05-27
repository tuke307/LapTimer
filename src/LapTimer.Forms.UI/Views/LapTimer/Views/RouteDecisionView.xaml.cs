namespace LapTimer.Forms.UI.Views.LapTimer
{
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// DriveInView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentView" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class RouteDecisionView : MvxContentView<ViewModels.LapTimer.RouteDecisionViewModel>
    {
        public RouteDecisionView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.LapTimer.RouteDecisionViewModel))
            {
                if (MvvmCross.Mvx.IoCProvider.TryResolve<ViewModels.LapTimer.RouteDecisionViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = MvvmCross.Mvx.IoCProvider.Resolve<MvvmCross.ViewModels.IMvxViewModelLoader>(); var
                request = new
                MvvmCross.ViewModels.MvxViewModelInstanceRequest(typeof(ViewModels.LapTimer.RouteDecisionViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.LapTimer.RouteDecisionViewModel;

                MvvmCross.Mvx.IoCProvider.RegisterSingleton<ViewModels.LapTimer.RouteDecisionViewModel>(ViewModel);
            }
        }
    }
}