using Data;
using Data.Enums;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LapTimer.Core.Services
{
    public class RideService : IRideService
    {
        private readonly DatabaseContext _context;
        private RideModel _ride;
        private List<RideModel> _rides = new List<RideModel>();
        private RouteModel _route;
        private RouteMode _routeEnum;
        private List<RouteModel> _routes = new List<RouteModel>();

        public RideService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddTrackpoint(TrackpointModel trackpoint)
        {
            //trackpoint;

            //_ride.Route.
        }

        public RideModel GetRide()
        {
            ReloadRides();

            return _ride;
        }

        public RouteModel GetRoute()
        {
            ReloadRoutes();

            return _route;
        }

        public bool IsModeSelected(RouteMode routeEnum)
        {
            return false;
        }

        public void SetRideMode(RouteMode routeEnum)
        {
            this._routeEnum = routeEnum;
        }

        public void SetRoute(RouteModel route)
        {
            _ride.Route = route;
        }

        private void ReloadRides()
        {
            _rides = _context.Rides.ToList();
        }

        private void ReloadRoutes()
        {
            _routes = _context.Routes.ToList();
        }
    }
}