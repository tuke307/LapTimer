﻿using LapTimer.Core.Services;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LapTimer.Forms.UI
{
    public static class ColorSettings
    {
        private const string userFile = "color";

        /// <summary>
        /// Gets or sets the MaterialDesignColors.PrimaryColor.
        /// </summary>
        /// <value>The primary.</value>
        public static int Primary
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(Primary), (int)PrimaryColor.Cyan, userFile);
            }

            set
            {
                AppSettings.AddOrUpdateValue(nameof(Primary), value, userFile);
            }
        }

        /// <summary>
        /// Gets or sets the MaterialDesignColors.SecondaryColor.
        /// </summary>
        /// <value>The secondary.</value>
        public static int Secondary
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(Secondary), (int)SecondaryColor.Teal, userFile);
            }

            set
            {
                AppSettings.AddOrUpdateValue(nameof(Secondary), value, userFile);
            }
        }

        /// <summary>
        /// Gets or sets the MaterialDesignThemes.Wpf.BaseTheme.
        /// </summary>
        /// <value>The theme.</value>
        public static int Theme
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(Theme), (int)BaseTheme.Inherit, userFile);
            }

            set
            {
                AppSettings.AddOrUpdateValue(nameof(Theme), value, userFile);
            }
        }

        private static ISettings AppSettings => CrossSettings.Current;
    }
}