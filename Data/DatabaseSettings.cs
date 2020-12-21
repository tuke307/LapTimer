namespace Data
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    /// <summary>
    /// Konstanten für die Datenbank-Abwicklung.
    /// </summary>
    public static class DatabaseSettings
    {
        /// <summary>
        /// The database name.
        /// </summary>
        public const string DatabaseName = "laptimer.db";

        /// <summary>
        /// Gets or sets the database path.
        /// </summary>
        /// <value>The database path.</value>
        public static string DatabasePath
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(DatabasePath), null);
            }

            set
            {
                AppSettings.AddOrUpdateValue(nameof(DatabasePath), value);
            }
        }

        private static ISettings AppSettings => CrossSettings.Current;
    }
}