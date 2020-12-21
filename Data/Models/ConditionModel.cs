using Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    /// <summary>
    /// ConditionModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class ConditionModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the ground.
        /// </summary>
        /// <value>The ground.</value>
        public GroundEnum? Ground { get; set; }

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
        /// Gets or sets the temperature.
        /// </summary>
        /// <value>The temperature.</value>
        public int? Temperature { get; set; }
    }
}