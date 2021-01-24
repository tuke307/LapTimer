namespace LapTimer.Forms.UI.ViewModels.Settings
{
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Services;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// SettingsViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class SettingsViewModel : MvxNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public SettingsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IThemeService themeService)
            : base(logProvider, navigationService)
        {
            this._themeService = themeService;
            BaseThemeValue = (BaseTheme)ColorSettings.Theme;

            CloseSiteCommand = new MvxAsyncCommand(() => this.NavigationService.Close(this));
        }

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Initialisierung.</returns>
        public override Task Initialize()
        {
            return base.Initialize();
        }

        /// <summary>
        /// Prepares this instance. called after construction.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();
        }

        #endregion Methods

        #region Values

        #region Commands

        public MvxAsyncCommand CloseSiteCommand { get; protected set; }

        #endregion Commands

        private readonly IThemeService _themeService;
        private Array _baseTheme = Enum.GetValues(typeof(BaseTheme));

        private BaseTheme? _baseThemeValue;

        public List<BaseTheme> BaseThemeList
        {
            get => _baseTheme.OfType<BaseTheme>().ToList();
        }

        /// <summary>
        /// Gets or sets the base theme value.
        /// </summary>
        /// <value>The base theme value.</value>
        public BaseTheme? BaseThemeValue
        {
            get => _baseThemeValue;
            set
            {
                if (_baseThemeValue != null)
                {
                    if (ColorSettings.Theme != (int)value.Value)
                    {
                        ColorSettings.Theme = (int)value.Value;
                        _themeService.UpdateTheme(value.Value);
                    }
                }

                this.SetProperty(ref _baseThemeValue, value);
            }
        }

        #endregion Values
    }
}