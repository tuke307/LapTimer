namespace LapTimer.Forms.UI.ViewModels
{
    using Data;
    using global::LapTimer.Forms.UI.Functions;
    using Microsoft.EntityFrameworkCore;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Xamarin.Essentials;

    /// <summary>
    /// MainViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class MainPageViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public MainPageViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
            this.InitializeDatabase = new MvxAsyncCommand(this.InitializeDatabaseAsync);
        }

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Initialisierung.</returns>
        public override async Task Initialize()
        {
            await base.Initialize();

            this.InitializeDatabase.Execute();
        }

        /// <summary>
        /// Prepares this instance. called after construction.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();
        }

        /// <summary>
        /// Views the appearing.
        /// </summary>
        public override void ViewAppearing()
        {
            if (this._firstTime)
            {
                this.ShowInitialViewModels();
                this._firstTime = false;
            }
        }

        /// <summary>
        /// Initializes the database asynchronous.
        /// </summary>
        private async Task InitializeDatabaseAsync()
        {
            await PermissionHelper.GetPermission<Permissions.StorageRead>().ConfigureAwait(true);
            await PermissionHelper.GetPermission<Permissions.StorageWrite>().ConfigureAwait(true);

            // android: "/data/user/0/com.tuke_productions.SimTuning/files/"
            Data.DatabaseSettings.FileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (string.IsNullOrEmpty(Data.DatabaseSettings.DatabasePath))
            {
                Data.DatabaseSettings.DatabasePath = Path.Combine(Data.DatabaseSettings.FileDirectory, Data.DatabaseSettings.DatabaseName);
            }

            // since android 10, database has to be created at the first time
            if (!File.Exists(Data.DatabaseSettings.DatabasePath))
            {
                var fs = File.Create(Data.DatabaseSettings.DatabasePath);
                fs.Dispose();
            }

            using (var db = new DatabaseContext())
            {
                await db.Database.MigrateAsync().ConfigureAwait(true);
            }
        }

        /// <summary>
        /// Shows the initial view models.
        /// </summary>
        /// <returns></returns>
        private Task ShowInitialViewModels()
        {
            var tasks = new List<Task>
            {
                this.NavigationService.Navigate<ViewModels.LapTimer.LapTimerTabViewModel>(),
                this.NavigationService.Navigate<ViewModels.Rides.RidesTabHosterViewModel>(),
                this.NavigationService.Navigate<ViewModels.Routes.RoutesTabHosterViewModel>()
            };
            return Task.WhenAll(tasks);
        }

        #endregion Methods

        #region Values

        private bool _firstTime = true;

        public IMvxAsyncCommand InitializeDatabase { get; protected set; }

        #endregion Values
    }
}