using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    /// <summary>
    /// LapModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class LapModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the distance meters.
        /// </summary>
        /// <value>The distance meters.</value>
        public double DistanceMeters { get; set; }

        /// <summary>
        /// Gets or sets the maximum speed.
        /// </summary>
        /// <value>The maximum speed.</value>
        public double MaximumSpeed { get; set; }

        /// <summary>
        /// Gets or sets the ride.
        /// </summary>
        /// <value>The ride.</value>
        [ForeignKey(nameof(RideId))]
        public virtual RideModel Ride { get; set; }

        /// <summary>
        /// Gets or sets the ride identifier.
        /// </summary>
        /// <value>The ride identifier.</value>
        public int RideId { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the total time seconds.
        /// </summary>
        /// <value>The total time seconds.</value>
        public double TotalTimeSeconds { get; set; }

        /// <summary>
        /// Gets or sets the trackpoints from the lap.
        /// </summary>
        /// <value>The trackpoints.</value>
        public List<TrackpointModel> Trackpoints { get; set; }
    }
}