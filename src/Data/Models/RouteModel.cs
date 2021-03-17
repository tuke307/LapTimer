namespace Data.Models
{
    using Data.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// RouteModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class RouteModel : BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rides.
        /// </summary>
        /// <value>The rides.</value>
        public virtual List<RideModel> Rides { get; set; }

        /// <summary>
        /// Gets or sets the route enum.
        /// </summary>
        /// <value>The route enum.</value>
        public RouteEnum RouteEnum { get; set; }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public virtual List<RouteTrackpointModel> Trackpoints { get; set; }
    }
}