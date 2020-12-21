using LapTimer.Forms.UI.Themes;

namespace LapTimer.Forms.UI.Services
{
    /// <summary>
    /// </summary>
    public interface IThemeService
    {
        /// <summary>
        /// Updates the theme.
        /// </summary>
        /// <param name="themeMode">The theme mode.</param>
        void UpdateTheme(BaseTheme themeMode);
    }
}