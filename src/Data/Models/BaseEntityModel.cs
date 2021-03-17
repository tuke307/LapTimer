// project=Data, file=BaseEntityModel.cs, creation=2020:6:28 Copyright (c) 2020 tuke
// productions. All rights reserved.
namespace Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// BaseModel.
    /// </summary>
    public class BaseEntityModel
    {
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }
    }
}