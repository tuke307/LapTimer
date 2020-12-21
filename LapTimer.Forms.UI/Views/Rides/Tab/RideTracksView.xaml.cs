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
    //[MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, Title = "Tracks", WrapInNavigationPage = true, NoHistory = false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RideTracksView : MvxContentView<ViewModels.Rides.RideTracksViewModel>
    {
        public RideTracksView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.Rides.RideTracksViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.Rides.RideTracksViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>(); var
                request = new
                MvxViewModelInstanceRequest(typeof(ViewModels.Rides.RideTracksViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.Rides.RideTracksViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.Rides.RideTracksViewModel>(ViewModel);
            }
        }

        private void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ViewModel.ActivityTappedCommand.Execute(e.Item);
            ListView.SelectedItem = null;
        }
    }
}