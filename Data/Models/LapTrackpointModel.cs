using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    /// <summary>
    /// TrackpointModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class LapTrackpointModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>The altitude.</value>
        public double? Altitude { get; set; }

        /// <summary>
        /// Gets or sets the ride.
        /// </summary>
        /// <value>The ride.</value>
        [ForeignKey(nameof(LapId))]
        public virtual LapModel Lap { get; set; }

        /// <summary>
        /// Gets or sets the ride identifier.
        /// </summary>
        /// <value>The ride identifier.</value>
        public int LapId { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }
    }
}