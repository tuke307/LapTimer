namespace Data.Models
{
    /// <summary>
    /// GroundModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class GroundModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the wind.
        /// </summary>
        /// <value>
        /// The wind.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the ride.
        /// </summary>
        /// <value>
        /// The ride.
        /// </value>
        public virtual RideModel Ride { get; set; }
    }
}