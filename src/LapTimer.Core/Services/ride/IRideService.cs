using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LapTimer.Core.Services
{
    public interface IRideService
    {
        void AddTrackpoint(TrackpointModel trackpoint);

        RideModel GetRide();

        bool IsModeSelected(RouteMode routeEnum);

        void SetRideMode(RouteMode routeEnum);

        void SetRoute(RouteModel route);
    }
}