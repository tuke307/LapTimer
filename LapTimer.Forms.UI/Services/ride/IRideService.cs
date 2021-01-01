using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LapTimer.Forms.UI.Services
{
    public interface IRideService
    {
        RideModel GetRide();

        bool IsModeSelected(RouteEnum routeEnum);

        void SetRideMode(RouteEnum routeEnum);

        void SetRoute(RouteModel route);
    }
}