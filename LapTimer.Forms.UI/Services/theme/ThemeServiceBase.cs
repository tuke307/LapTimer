namespace LapTimer.Forms.UI.Services
{
    using LapTimer.Forms.UI.Themes;
    using Xamarin.Forms;

    /// <summary>
    /// ThemeServiceBase.
    /// </summary>
    /// <seealso cref="LapTimer.Forms.UI.Services.IThemeService" />
    public class ThemeServiceBase : IThemeService
    {
        /// <summary>
        /// Gets the current runtime theme.
        /// </summary>
        /// <value>The current runtime theme.</value>
        public BaseTheme CurrentRuntimeTheme { get; private set; }

        /// <summary>
        /// Updates the theme.
        /// </summary>
        /// <param name="themeMode">The theme mode.</param>
        public virtual void UpdateTheme(BaseTheme themeMode)
        {
            switch (ColorSettings.Theme)
            {
                case (int)BaseTheme.Inherit:
                    if (themeMode == BaseTheme.Dark)
                        goto case (int)BaseTheme.Dark;
                    else
                        goto case (int)BaseTheme.Light;
                case (int)BaseTheme.Dark:
                    SetTheme(BaseTheme.Dark);
                    break;

                case (int)BaseTheme.Light:
                    SetTheme(BaseTheme.Light);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the colors.
        /// </summary>
        /// <param name="themeMode">The theme mode.</param>
        private void SetColors(BaseTheme themeMode)
        {
            //var colors = themeMode.ToResourceDictionary(CustomColors);

            var mergedDir = Application.Current.Resources.MergedDictionaries;
            //mergedDir.Remove(mergedDir.Where(x => x.Keys.Contains(nameof(DarkTheme.MaterialDesignBackground))).First());

            switch (themeMode)
            {
                case Themes.BaseTheme.Inherit:
                    break;

                case Themes.BaseTheme.Light:
                    mergedDir.Add(new Themes.Base.Light());
                    break;

                case Themes.BaseTheme.Dark:
                    mergedDir.Add(new Themes.Base.Dark());
                    break;

                default:
                    break;
            }

            XF.Material.Forms.Material.Use("Material.Configuration");
        }

        /// <summary>
        /// Sets the theme.
        /// </summary>
        /// <param name="themeMode">The theme mode.</param>
        private void SetTheme(BaseTheme themeMode)
        {
            if (CurrentRuntimeTheme == themeMode)
            {
                return;
            }

            this.SetColors(themeMode);

            CurrentRuntimeTheme = themeMode;
        }
    }
}