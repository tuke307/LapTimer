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
        public static async Task<bool> GetPermission<TPermission>()
            where TPermission : BasePermission, new()
        {
            var hasPermission = await CheckStatusAsync<TPermission>().ConfigureAwait(true);

            if (hasPermission == PermissionStatus.Granted)
            {
                return true;
            }
            else if (hasPermission == PermissionStatus.Disabled)
            {
                return false;
            }

            var result = await RequestAsync<TPermission>().ConfigureAwait(true);
            if (result != PermissionStatus.Granted)
            {
                return false;
            }

            return true;
        }
    }
}