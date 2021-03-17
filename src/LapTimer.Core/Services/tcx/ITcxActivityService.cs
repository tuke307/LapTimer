using System;
using System.Threading.Tasks;

using TcxTools;

namespace LapTimer.Core.Services
{
    /// <summary>
    /// ITcxActivityService.
    /// </summary>
    public interface ITcxActivityService
    {
        /// <summary>
        /// Gets the activities asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<System.Collections.Generic.List<Activity>> GetActivitiesAsync();

        /// <summary>
        /// Gets the activity asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Activity> GetActivityAsync(string id);
    }
}