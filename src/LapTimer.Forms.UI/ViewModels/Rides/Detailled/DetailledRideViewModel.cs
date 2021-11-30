namespace LapTimer.Forms.UI.ViewModels.Rides
{
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Models;
    using global::LapTimer.Forms.UI.Services;
    using global::LapTimer.SkiaSharp.Models;
    using global::LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap;
    using global::LapTimer.SkiaSharp.ViewModels;
    using Microsoft.Extensions.Logging;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using Sharpnado.Presentation.Forms;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// DetailledRideViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class DetailledRideViewModel : MvxNavigationViewModel<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailledRideViewModel" /> class.
        /// </summary>
        /// <param name="logFactory">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public DetailledRideViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService, ITcxActivityService tcxactivityService)
            : base(logFactory, navigationService)
        {
            DeleteRideCommand = new MvxAsyncCommand(DeleteRide);
            CloseSiteCommand = new MvxAsyncCommand(() => this.NavigationService.Close(this));
            Loader = new TaskLoaderNotifier<SessionMap>();
            _tcxActivityService = tcxactivityService;
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
        public override void Prepare(string activityId)
        {
            var date = DateTime.ParseExact(activityId, "yyyyMMdd_HHmm", CultureInfo.InvariantCulture);
            Title = date.ToLongDateString();

            Loader.Load(() => LoadAsync(activityId));
        }

        private Task DeleteRide()
        {
            throw new NotImplementedException();
        }

        private async Task<SessionMap> LoadAsync(string activityId)
        {
            var activity = await _tcxActivityService.GetActivityAsync(activityId);

            if (activity.Lap[0].Track.Count < 2)
            {
                return null;
            }

            var activityPoints = activity.ToActivityPoints();
            var activityHeader = activity.ToActivityHeader();
            Header = new ActivityHeaderModel(activityHeader, new List<IDispersionSpan>());
            await RaisePropertyChanged(() => Header);

            SessionMap mapInfo;

            mapInfo = SessionMap.Create(activityPoints);

            GraphInfo = SessionGraph.CreateSessionGraphInfo(mapInfo.SessionPoints);
            await RaisePropertyChanged(() => GraphInfo);

            return mapInfo;
        }

        private void OnCurrentTimeChanged()
        {
            if (GraphInfo == null)
            {
                return;
            }

            var currentPoint = GraphInfo.SessionPoints.First(p => p.Time >= CurrentTime);

            //CurrentHeartRate = currentPoint.HeartRate?.ToString() ?? Functions.Functions.GetLocalisedRes(typeof(Resx.resources), "NoValue");
            CurrentSpeed = currentPoint.Speed?.ToString("0.0") ?? Functions.Resources.GetLocalisedRes(typeof(Core.Resx.strings.res_str), nameof(Core.Resx.strings.res_str.NoValue));
            CurrentAltitude = currentPoint.Altitude?.ToString() ?? Functions.Resources.GetLocalisedRes(typeof(Core.Resx.strings.res_str), nameof(Core.Resx.strings.res_str.NoValue));
            CurrentDistance = currentPoint.Distance != null
                ? (currentPoint.Distance.Value / 1000f).ToString("0.0") : Functions.Resources.GetLocalisedRes(typeof(Core.Resx.strings.res_str), nameof(Core.Resx.strings.res_str.NoValue));
        }

        #endregion Methods

        #region Values

        protected readonly IDbActivityService _dbactivityService;
        protected readonly ITcxActivityService _tcxActivityService;
        private string _currentAltitude;
        private string _currentDistance;
        private string _currentSpeed;
        private TimeSpan _currentTime;

        private string _title;

        public MvxAsyncCommand CloseSiteCommand { get; protected set; }

        public string CurrentAltitude
        {
            get => _currentAltitude;
            set => SetProperty(ref _currentAltitude, value);
        }

        public string CurrentDistance
        {
            get => _currentDistance;
            set => SetProperty(ref _currentDistance, value);
        }

        public string CurrentSpeed
        {
            get => _currentSpeed;
            set => SetProperty(ref _currentSpeed, value);
        }

        public TimeSpan CurrentTime
        {
            get => _currentTime;
            set
            {
                SetProperty(ref _currentTime, value);
                OnCurrentTimeChanged();
            }
        }

        public MvxAsyncCommand DeleteRideCommand { get; protected set; }

        public SessionGraph GraphInfo { get; private set; }

        public ActivityHeaderModel Header { get; private set; }

        public TaskLoaderNotifier<SessionMap> Loader { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion Values
    }
}