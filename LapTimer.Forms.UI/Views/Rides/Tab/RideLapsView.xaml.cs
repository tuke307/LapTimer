namespace LapTimer.Forms.UI.Views.Rides
{
    using MvvmCross;
    using MvvmCross.Forms.Presenters.Attributes;
    using MvvmCross.Forms.Views;
    using MvvmCross.ViewModels;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// RideLapsView.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Views.MvxContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RideLapsView : MvxContentView<ViewModels.Rides.RideLapsViewModel>
    {
        public RideLapsView()
        {
            InitializeComponent();

            if (!(ViewModel is ViewModels.Rides.RideLapsViewModel))
            {
                if (Mvx.IoCProvider.TryResolve<ViewModels.Rides.RideLapsViewModel>(out var miniPlayerViewModel))
                {
                    ViewModel = miniPlayerViewModel;
                    return;
                }

                var _viewModelLoader = Mvx.IoCProvider.Resolve<IMvxViewModelLoader>(); var
                request = new
                MvxViewModelInstanceRequest(typeof(ViewModels.Rides.RideLapsViewModel));
                request.ViewModelInstance = _viewModelLoader.LoadViewModel(request, null);
                ViewModel = request.ViewModelInstance as ViewModels.Rides.RideLapsViewModel;

                Mvx.IoCProvider.RegisterSingleton<ViewModels.Rides.RideLapsViewModel>(ViewModel);
            }
        }

        private void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ViewModel.ActivityTappedCommand.Execute(e.Item);
            ListView.SelectedItem = null;
        }
    }
}