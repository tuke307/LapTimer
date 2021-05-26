namespace LapTimer.Forms.UI.Services
{
    using LapTimer.Core.Services;
    using LapTimer.Forms.UI.Styles;
    using Sharpnado.MaterialFrame;
    using System;
    using System.Reflection;
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

        //public static void SetDarkMode()
        //{
        //    //foreach (FieldInfo field in typeof(IBaseTheme).GetFields(/*BindingFlags.Static | BindingFlags.Public*/))
        //    //{
        //    //    SetDynamicResource(field.Name, field.Name + "Dark");
        //    //}

        //    MaterialFrame.ChangeGlobalTheme(MaterialFrame.Theme.Dark);
        //}

        //public static void SetDynamicResource(string targetResourceName, string sourceResourceName)
        //{
        //    if (!Application.Current.Resources.TryGetValue(sourceResourceName, out var value))
        //    {
        //        throw new InvalidOperationException($"key {sourceResourceName} not found in the resource dictionary");
        //    }

        //    Application.Current.Resources[targetResourceName] = value;
        //}

        //public static void SetDynamicResource<T>(string targetResourceName, T value)
        //{
        //    Application.Current.Resources[targetResourceName] = value;
        //}

        //public static void SetLightMode()
        //{
        //    //foreach (FieldInfo field in typeof(IBaseTheme).GetFields(/*BindingFlags.Static | BindingFlags.Public*/))
        //    //{
        //    //    SetDynamicResource(field.Name, field.Name + "Light");
        //    //}

        //    MaterialFrame.ChangeGlobalTheme(MaterialFrame.Theme.Light);
        //}

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
        //private void SetColors(BaseTheme themeMode)
        //{
        //    switch (themeMode)
        //    {
        //        case BaseTheme.Inherit:
        //            break;

        //        case BaseTheme.Light:
        //            SetLightMode();
        //            break;

        //        case BaseTheme.Dark:
        //            SetDarkMode();
        //            break;

        //        default:
        //            break;
        //    }
        //}

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

            //this.SetColors(themeMode);

            CurrentRuntimeTheme = themeMode;
        }
    }
}