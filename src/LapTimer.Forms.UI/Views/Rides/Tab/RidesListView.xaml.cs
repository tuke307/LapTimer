namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross;
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using MvvmCross.ViewModels;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RideTracksView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RidesListView : MvxContentView<ViewModels.Rides.RidesListViewModel>
    {
        public RidesListView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.Rides.RidesListViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.Rides.RidesListViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>(); var
                request = new
                MvxViewModelInstanceRequest(typeof(ViewModels.Rides.RidesListViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.Rides.RidesListViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.Rides.RidesListViewModel>(ViewModel);
            }
        }

        private void ListViewOnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}