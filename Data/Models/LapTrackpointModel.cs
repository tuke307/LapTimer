using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    /// <summary>
    /// TrackpointModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class LapTrackpointModel : TrackpointModel
    {
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
    }
}