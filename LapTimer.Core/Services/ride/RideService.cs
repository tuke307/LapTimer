﻿using Data.Enums;
using Data.Models;

namespace LapTimer.Core.Services
{
    public class RideService : IRideService
    {
        private RideModel ride;
        private RouteModel route;

        public RideModel GetRide()
        {
            return ride;
        }

        public bool IsModeSelected(RouteEnum routeEnum)
        {
            return false;
        }

        public void SetRideMode(RouteEnum routeEnum)
        {
            //routeEnum
        }

        public void SetRoute(RouteModel route)
        {
            ride.Route = route;
        }
    }
}