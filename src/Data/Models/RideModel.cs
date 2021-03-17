using System.Collections.Generic;

namespace Data.Models
{
    /// <summary>
    /// RideModel.
    /// </summary>
    /// <seealso cref="Data.Models.BaseEntityModel" />
    public class RideModel : BaseEntityModel
    {
        /// <summary>
        /// The laps.
        /// </summary>
        public List<LapModel> Laps;

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public virtual ConditionModel Condition { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        public virtual RouteModel Route { get; set; }
    }
}