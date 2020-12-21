using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LapTimer.Forms.UI.Services
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
        Task<List<RideModel>> GetLapRidesAsync();

        /// <summary>
        /// Gets the lap routes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<RouteModel>> GetLapRoutesAsync();

        /// <summary>
        /// Gets the track rides asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<RideModel>> GetTrackRidesAsync();

        /// <summary>
        /// Gets the track routes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<RouteModel>> GetTrackRoutesAsync();
    }
}