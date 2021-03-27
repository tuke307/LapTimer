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
    public partial class RoutesListView : MvxContentView<ViewModels.Routes.RoutesListViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutesListView"/> class.
        /// </summary>
        public RoutesListView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.Routes.RoutesListViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.Routes.RoutesListViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>(); var
                request = new
                MvxViewModelInstanceRequest(typeof(ViewModels.Routes.RoutesListViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.Routes.RoutesListViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.Routes.RoutesListViewModel>(ViewModel);
            }
        }

        private void ListViewOnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}