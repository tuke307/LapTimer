namespace LapTimer.Forms.UI.Views.Routes
{
    using MvvmCross;
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using MvvmCross.ViewModels;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RouteLapsView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteLapsView : MvxContentView<ViewModels.Routes.RouteLapsViewModel>
    {
        public RouteLapsView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.Routes.RouteLapsViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.Routes.RouteLapsViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>(); var
                request = new
                MvxViewModelInstanceRequest(typeof(ViewModels.Routes.RouteLapsViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.Routes.RouteLapsViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.Routes.RouteLapsViewModel>(ViewModel);
            }
        }

        private void ListViewOnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}