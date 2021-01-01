using System.Threading.Tasks;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace LapTimer.Forms.UI.Functions
{
    public static class PermissionHelper
    {
        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <typeparam name="TPermission">The type of the permission.</typeparam>
        /// <returns></returns>
        public static async Task<PermissionStatus> GetPermission<TPermission>()
            where TPermission : BasePermission, new()
        {
            var status = await CheckStatusAsync<TPermission>().ConfigureAwait(true);

            if (status != PermissionStatus.Granted)
            {
                status = await RequestAsync<TPermission>().ConfigureAwait(true);
            }

            return status;
        }
    }
}