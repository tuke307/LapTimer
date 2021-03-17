using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class RouteTrackpointModel : TrackpointModel
    {
        /// <summary>
        /// Gets or sets the ride.
        /// </summary>
        /// <value>The ride.</value>
        [ForeignKey(nameof(RouteId))]
        public virtual RouteModel Route { get; set; }

        /// <summary>
        /// Gets or sets the ride identifier.
        /// </summary>
        /// <value>The ride identifier.</value>
        public int RouteId { get; set; }
    }
}