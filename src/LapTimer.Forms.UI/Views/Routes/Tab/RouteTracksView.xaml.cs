namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross;
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using MvvmCross.ViewModels;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RouteTracksView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteTracksView : MvxContentView<ViewModels.Routes.RouteTracksViewModel>
    {
        public RouteTracksView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.Routes.RouteTracksViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.Routes.RouteTracksViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>(); var
                request = new
                MvxViewModelInstanceRequest(typeof(ViewModels.Routes.RouteTracksViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.Routes.RouteTracksViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.Routes.RouteTracksViewModel>(ViewModel);
            }
        }

        private void ListViewOnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}