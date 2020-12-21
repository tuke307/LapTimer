namespace LapTimer.Forms.UI.ViewModels.Rides
{
    using global::LapTimer.Forms.UI.Models;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using Sharpnado.Presentation.Forms;
    using SkiaSharpnado.Maps.Presentation.ViewModels.SessionMap;
    using SkiaSharpnado.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// DetailledRideViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class DetailledRideViewModel : MvxNavigationViewModel<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailledRideViewModel" /> class.
        /// </summary>
        /// <param name="logProvider">The log provider.</param>
        /// <param name="navigationService">The navigation service.</param>
        public DetailledRideViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
            Loader = new TaskLoaderNotifier<SessionMapInfo>(/*emptyStateMessage: AppResources.EmptyActivityMessage*/);
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
            //string activityId = parameters.GetValue<string>("activityId");

            var date = DateTime.ParseExact(activityId, "yyyyMMdd_HHmm", CultureInfo.InvariantCulture);
            //Title = date.ToLongDateString();

            Loader.Load(() => LoadAsync(activityId));
        }

        /// <summary>
        /// Prepares this instance. called after construction.
        /// </summary>
        public override void Prepare()
        {
            base.Prepare();
        }

        private async Task<SessionMapInfo> LoadAsync(string activityId)
        {
            //var activity = await _activityService.GetActivityAsync(activityId);

            ////if (activity.Lap[0].Track.Count < 2)
            ////{
            ////    return null;
            ////}

            ////var activityPoints = activity.ToActivityPoints();
            ////var activityHeader = activity.ToActivityHeader();
            ////Header = new ActivityHeaderViewModel(activityHeader, new List<IDispersionSpan>());
            ////RaisePropertyChanged(nameof(Header));

            //double maxSpeed = activity.Lap[0].MaximumSpeed * 3.6f;
            //Color? SelectColorBySpeed(ISessionDisplayablePoint point)
            //{
            //    if (point.Speed == null)
            //    {
            //        return null;
            //    }

            //    return HumanEffortComputer.BySpeed.GetColor(point.Speed, maxSpeed);
            //}

            ////Color? SelectColorByHeartRate(ISessionDisplayablePoint point)
            ////{
            ////    if (point.HeartRate == null)
            ////    {
            ////        return null;
            ////    }

            ////    return HumanEffortComputer.ByHeartBeat.GetColor(point.HeartRate);
            ////}

            ////int markerInterval = 100;
            ////int distanceInternal = 100;
            ////int totalDistance = activityHeader.DistanceInMeters;
            ////if (totalDistance >= 100000)
            ////{
            ////    markerInterval = 5000;
            ////    distanceInternal = 10000;
            ////}
            ////else if (totalDistance >= 50000)
            ////{
            ////    markerInterval = 2000;
            ////    distanceInternal = 5000;
            ////}
            ////else if (totalDistance >= 10000)
            ////{
            ////    markerInterval = 1000;
            ////    distanceInternal = 2000;
            ////}
            ////else if (totalDistance >= 5000)
            ////{
            ////    markerInterval = 500;
            ////    distanceInternal = 1000;
            ////}

            //SessionMapInfo mapInfo;
            ////if (Header.AverageHeartRate.HasValue)
            ////{
            ////    mapInfo = SessionMapInfo.Create(
            ////        activityPoints,
            ////        SelectColorByHeartRate,
            ////        markerInterval,
            ////        distanceInternal);
            ////}
            ////else
            ////{
            //mapInfo = SessionMapInfo.Create(
            //    activityPoints,
            //    SelectColorBySpeed,
            //    1000,
            //    1000);
            ////}

            ////GraphInfo = SessionGraphInfo.CreateSessionGraphInfo(mapInfo.SessionPoints);
            ////await RaisePropertyChanged(nameof(GraphInfo));

            //return mapInfo;
            return null;
        }

        private void OnCurrentTimeChanged()
        {
            if (GraphInfo == null)
            {
                return;
            }

            var currentPoint = GraphInfo.SessionPoints.First(p => p.Time >= CurrentTime);

            //CurrentHeartRate = currentPoint.HeartRate?.ToString() ?? Functions.Functions.GetLocalisedRes(typeof(Resx.resources), "NoValue");
            CurrentSpeed = currentPoint.Speed?.ToString("0.0") ?? Functions.Resources.GetLocalisedRes(typeof(Resx.resources), nameof(Resx.resources.NoValue));
            CurrentAltitude = currentPoint.Altitude?.ToString() ?? Functions.Resources.GetLocalisedRes(typeof(Resx.resources), nameof(Resx.resources.NoValue));
            CurrentDistance = currentPoint.Distance != null
                ? (currentPoint.Distance.Value / 1000f).ToString("0.0") : Functions.Resources.GetLocalisedRes(typeof(Resx.resources), nameof(Resx.resources.NoValue));
        }

        #endregion Methods

        #region Values

        private string _currentAltitude;
        private string _currentDistance;
        private string _currentSpeed;
        private TimeSpan _currentTime;

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

        public SessionGraphInfo GraphInfo { get; private set; }

        public ActivityHeaderModel Header { get; private set; }

        public TaskLoaderNotifier<SessionMapInfo> Loader { get; }

        #endregion Values
    }
}