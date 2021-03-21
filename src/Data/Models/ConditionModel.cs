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
        /// Gets or sets the clouds.
        /// </summary>
        /// <value>
        /// The clouds.
        /// </value>
        public bool? Clouds { get; set; }

        /// <summary>
        /// Gets or sets the precipation.
        /// </summary>
        /// <value>
        /// The precipation.
        /// </value>
        public bool? Precipation { get; set; }

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
        /// Gets or sets the wind.
        /// </summary>
        /// <value>
        /// The wind.
        /// </value>
        public int? Wind { get; set; }
    }
}