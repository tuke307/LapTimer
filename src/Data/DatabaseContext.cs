namespace Data
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    /// <summary>
    /// Main Funktionalität der DB.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class DatabaseContext : DbContext
    {
        #region DataSets

        /// <summary>
        /// Gets or sets the conditions.
        /// </summary>
        /// <value>The conditions.</value>
        public DbSet<ConditionModel> Conditions { get; set; }

        /// <summary>
        /// Gets or sets the laps.
        /// </summary>
        /// <value>The laps.</value>
        public DbSet<LapModel> Laps { get; set; }

        /// <summary>
        /// Gets or sets the lap trackpoints.
        /// </summary>
        /// <value>The lap trackpoints.</value>
        public DbSet<LapTrackpointModel> LapTrackpoints { get; set; }

        /// <summary>
        /// Gets or sets the rides.
        /// </summary>
        /// <value>The rides.</value>
        public DbSet<RideModel> Rides { get; set; }

        /// <summary>
        /// Gets or sets the routes.
        /// </summary>
        /// <value>The routes.</value>
        public DbSet<RouteModel> Routes { get; set; }

        /// <summary>
        /// Gets or sets the route trackpoints.
        /// </summary>
        /// <value>The route trackpoints.</value>
        public DbSet<RouteTrackpointModel> RouteTrackpoints { get; set; }

        #endregion DataSets

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext" /> class.
        /// </summary>
        public DatabaseContext()
        {
        }

        /// <summary>
        /// Aufgerufen beim speichern der Entitys.
        /// </summary>
        /// <returns>The Number of state entries.</returns>
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntityModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                // Modified Date
                ((BaseEntityModel)entityEntry.Entity).UpdatedDate = DateTime.Now;

                // Creation Date
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntityModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// einmaliger Aufruf.
        /// </summary>
        /// <param name="options">Optionen.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={DatabaseSettings.DatabasePath}");
        }
    }
}