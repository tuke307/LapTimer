namespace LapTimer.Forms.UI.Services
{
    using LapTimer.Forms.UI.Themes;
    using Xamarin.Forms;

    public class ThemeServiceBase : IThemeService
    {
        public BaseTheme CurrentRuntimeTheme { get; private set; }

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