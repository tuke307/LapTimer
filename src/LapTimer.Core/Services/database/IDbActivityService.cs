using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LapTimer.Core.Services
{
    /// <summary>
    /// IActivityService.
    /// </summary>
    public interface IDbActivityService
    {
        /// <summary>
        /// Gets the lap rides asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<RideModel>> GetRidesAsync();

        /// <summary>
        /// Gets the lap routes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<RouteModel>> GetRoutesAsync();
    }
}