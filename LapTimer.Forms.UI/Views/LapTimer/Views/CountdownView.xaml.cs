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

            if (!(ViewModel is ViewModels.LapTimer.CountdownViewModel))
            {
                if (MvvmCross.Mvx.IoCProvider.TryResolve<ViewModels.LapTimer.CountdownViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = MvvmCross.Mvx.IoCProvider.Resolve<MvvmCross.ViewModels.IMvxViewModelLoader>(); var
                request = new
                MvvmCross.ViewModels.MvxViewModelInstanceRequest(typeof(ViewModels.LapTimer.CountdownViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.LapTimer.CountdownViewModel;

                MvvmCross.Mvx.IoCProvider.RegisterSingleton<ViewModels.LapTimer.CountdownViewModel>(ViewModel);
            }
        }
    }
}