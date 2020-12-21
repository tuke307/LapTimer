using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LapTimer.Forms.UI.Services
{
    public interface IActivityService
    {
        Task<List<RideModel>> GetLapRidesAsync();

        Task<List<RouteModel>> GetLapRoutesAsync();

        Task<List<RideModel>> GetTrackRidesAsync();

        Task<List<RouteModel>> GetTrackRoutesAsync();
    }
}