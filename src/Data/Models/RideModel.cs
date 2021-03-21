using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Gets or sets the distance meters.
        /// </summary>
        /// <value>The distance meters.</value>
        public double DistanceMeters { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the ground.
        /// </summary>
        /// <value>
        /// The ground.
        /// </value>
        [ForeignKey(nameof(GroundId))]
        public virtual GroundModel Ground { get; set; }

        /// <summary>
        /// Gets or sets the ground identifier.
        /// </summary>
        /// <value>
        /// The ground identifier.
        /// </value>
        public int GroundId { get; set; }

        /// <summary>
        /// Gets or sets the maximum speed.
        /// </summary>
        /// <value>The maximum speed.</value>
        public double MaximumSpeed { get; set; }

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

        /// <summary>
        /// Gets or sets the route enum.
        /// </summary>
        /// <value>The route enum.</value>
        public RouteMode RouteEnum { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; set; }
    }
}