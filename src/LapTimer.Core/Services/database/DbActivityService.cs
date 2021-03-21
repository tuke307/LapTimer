using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LapTimer.Core.Services
{
    /// <summary>
    /// ActivityService.
    /// </summary>
    /// <seealso cref="LapTimer.Core.Services.IDbActivityService" />
    public class DbActivityService : IDbActivityService
    {
        private readonly List<RideModel> _rides = new List<RideModel>();

        private readonly List<RouteModel> _routes = new List<RouteModel>();

        /// <summary>
        /// Gets the track rides asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RideModel>> GetRidesAsync()
        {
            if (_rides.Count == 0)
            {
                await LoadRides();
            }

            return _rides;
        }

        /// <summary>
        /// Gets the lap routes asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RouteModel>> GetRoutesAsync()
        {
            if (_routes.Count == 0)
            {
                await LoadRoutes();
            }

            return _routes;
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
                    .Include(r => r.Ground)
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