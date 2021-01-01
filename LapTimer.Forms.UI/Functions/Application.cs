using Data;
using LapTimer.Forms.UI.Services;
using LapTimer.Forms.UI.Themes;
using Microsoft.EntityFrameworkCore;
using MvvmCross;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XF.Material.Forms.UI.Dialogs;

namespace LapTimer.Forms.UI.Functions
{
    public static class Application
    {
        /// <summary>
        /// Initializes the database asynchronous.
        /// </summary>
        public static async Task InitializeLapTimerApplication()
        {
            // permissions
            PermissionStatus storageRead = await PermissionHelper.GetPermission<Permissions.StorageRead>().ConfigureAwait(true);
            PermissionStatus storageWrite = await PermissionHelper.GetPermission<Permissions.StorageWrite>().ConfigureAwait(true);

            if (storageRead != PermissionStatus.Granted || storageWrite != PermissionStatus.Granted)
            {
                var dialog = await MaterialDialog.Instance.ConfirmAsync(message: "Check your permission settings",
                                     title: "Alert");

                if (dialog.HasValue)
                {
                    Mvx.IoCProvider.Resolve<ICloseApplicationService>().CloseApplication();
                }
            }

            // android: "/data/user/0/com.tuke_productions.LapTimer/files/"
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
    }
}