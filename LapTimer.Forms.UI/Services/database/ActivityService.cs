using Data;
using Data.Enums;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LapTimer.Forms.UI.Services
{
    /// <summary>
    /// ActivityService.
    /// </summary>
    /// <seealso cref="LapTimer.Forms.UI.Services.IActivityService" />
    public class ActivityService : IActivityService
    {
        private readonly List<RideModel> _rides = new List<RideModel>();

        private readonly List<RouteModel> _routes = new List<RouteModel>();

        /// <summary>
        /// Gets the lap rides asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RideModel>> GetLapRidesAsync()
        {
            if (_rides.Count == 0)
            {
                await LoadRides();
            }

            return _rides.Where(r => r.Route.RouteEnum == RouteEnum.Lap).ToList();
        }

        /// <summary>
        /// Gets the lap routes asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RouteModel>> GetLapRoutesAsync()
        {
            if (_routes.Count == 0)
            {
                await LoadRoutes();
            }

            return _routes.Where(r => r.RouteEnum == RouteEnum.Lap).ToList();
        }

        /// <summary>
        /// Gets the track rides asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RideModel>> GetTrackRidesAsync()
        {
            if (_rides.Count == 0)
            {
                await LoadRides();
            }

            return _rides.Where(r => r.Route.RouteEnum == RouteEnum.Track).ToList();
        }

        /// <summary>
        /// Gets the track routes asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RouteModel>> GetTrackRoutesAsync()
        {
            if (_routes.Count == 0)
            {
                await LoadRoutes();
            }

            return _routes.Where(r => r.RouteEnum == RouteEnum.Track).ToList();
        }

        /// <summary>
        /// Loads the rides.
        /// </summary>
        private async Task LoadRides()
        {
            using (var db = new DatabaseContext())
            {
                var rides = await db.Rides
                    .Include(r => r.Condition)
                    .Include(r => r.Route)
                    .ToListAsync();
                _rides.AddRange(rides);
            }
        }

        /// <summary>
        /// Loads the routes.
        /// </summary>
        private async Task LoadRoutes()
        {
            using (var db = new DatabaseContext())
            {
                var routes = await db.Routes
                    .Include(r => r.Rides)
                    .ToListAsync();
                _routes.AddRange(routes);
            }
        }
    }
}