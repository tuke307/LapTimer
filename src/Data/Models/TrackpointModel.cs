using MvvmCross.Plugin.Location;

namespace Data.Models
{
    /// <summary>
    /// TrackpointModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class TrackpointModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>The altitude.</value>
        public double? Altitude { get; set; }

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

        public TrackpointModel()
        {
        }

        public TrackpointModel(MvxCoordinates mvxCoordinates)
        {
            Altitude = mvxCoordinates.Altitude;
            Latitude = mvxCoordinates.Latitude;
            Longitude = mvxCoordinates.Longitude;
        }
    }
}