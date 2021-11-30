namespace LapTimer.Forms.UI.ViewModels.Routes
{
    using Data.Models;
    using global::LapTimer.Core.Services;
    using global::LapTimer.Forms.UI.Models;
    using global::LapTimer.Forms.UI.Services;
    using global::LapTimer.SkiaSharp.Helpers;
    using global::LapTimer.SkiaSharp.Models;
    using global::LapTimer.SkiaSharp.ViewModels;
    using Microsoft.Extensions.Logging;
    using MvvmCross.Commands;
    using MvvmCross.Logging;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using Sharpnado.Presentation.Forms;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TcxTools;

    /// <summary>
    /// RouteLapsViewModel.
    /// </summary>
    /// <seealso cref="MvvmCross.ViewModels.MvxNavigationViewModel" />
    public class RouteTabViewModel : MvxNavigationViewModel
    {
        public RouteTabViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService, IDbActivityService dbactivityService, ITcxActivityService tcxActivityService)
             : base(logFactory, navigationService)
        {
            _dbactivityService = dbactivityService;
            _tcxActivityService = tcxActivityService;

            Loader = new TaskLoaderNotifier<List<ActivityHeaderModel>>();
            ActivityTappedCommand = new MvxCommand<ActivityHeaderModel>(item => NavigationService.Navigate<DetailledRouteViewModel>(item.Id));
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

        /// <summary>
        /// Views the appeared.
        /// </summary>
        public override void ViewAppeared()
        {
            base.ViewAppeared();

            if (Loader.IsSuccessfullyCompleted)
            {
                return;
            }

            Loader.Load(LoadAsync);
        }

        protected Task<ActivityHeaderModel> CreateHeaderViewModelAsync(RideModel ride)
        {
            return Task.Run(
                 () =>
                 {
                     var lap = ride.Laps[0];

                     double maxSpeed = lap.MaximumSpeed * 3.6;
                     EffortComputer effortComputer = HumanEffortComputer.BySpeed.OverrideDefaultMaxValue(maxSpeed);

                     var dispersion = new SortedDictionary<double, IDispersionSpan>();
                     var previousPoint = lap.Trackpoints[0];
                     DateTime startTime = lap.Trackpoints[0].CreatedDate.Value;
                     for (int index = 0; index < lap.Trackpoints.Count; index++)
                     {
                         var currentPoint = lap.Trackpoints[index];

                         TimeSpan elapsedTime = currentPoint.CreatedDate.Value - startTime;

                         double? speed = null;
                         if (previousPoint != null && previousPoint.Latitude != null && previousPoint.Longitude != null
                            && /*previousPoint.DistanceMeters > 0 && currentPoint.Position != null
                            && currentPoint.DistanceMeters > 0 &&*/ elapsedTime.TotalSeconds > 0)
                         {
                             double kilometersTraveled = GeoCalculation.HaversineDistance(
                                new LatLong(
                                    previousPoint.Latitude,
                                    previousPoint.Longitude),
                                new LatLong(
                                    currentPoint.Latitude,
                                    currentPoint.Longitude));
                             double hoursElapsed = (elapsedTime - (previousPoint.CreatedDate.Value - startTime)).TotalHours;
                             speed = kilometersTraveled / hoursElapsed;
                         }

                         //double? value = lap.AverageHeartRateBpm != null ? currentPoint.HeartRateBpm?.Value : speed;
                         //if (value == null)
                         //{
                         //    previousPoint = currentPoint;
                         //    continue;
                         //}

                         //var elapsedTimeSinceLastPoint = currentPoint.CreatedDate - previousPoint.CreatedDate;
                         //EffortSpan effortSpan = effortComputer.GetSpan(value);
                         //if (!dispersion.ContainsKey(effortSpan.Threshold))
                         //{
                         //    dispersion.Add(effortSpan.Threshold, new DispersionSpan(effortSpan.Color, 0));
                         //}

                         //dispersion[effortSpan.Threshold]
                         //   .IncrementValue(elapsedTimeSinceLastPoint.TotalMilliseconds);

                         previousPoint = currentPoint;
                     }

                     return new ActivityHeaderModel(ride.ToActivityHeader(), dispersion.Values.ToList());
                 });
        }

        protected Task<ActivityHeaderModel> CreateHeaderViewModelAsync(Activity activity)
        {
            return Task.Run(
                () =>
                {
                    var lap = activity.Lap[0];

                    double maxSpeed = lap.MaximumSpeed * 3.6;
                    EffortComputer effortComputer = HumanEffortComputer.BySpeed.OverrideDefaultMaxValue(maxSpeed);

                    var dispersion = new SortedDictionary<double, IDispersionSpan>();
                    Trackpoint previousPoint = lap.Track[0];
                    DateTime startTime = lap.Track[0].Time;
                    for (int index = 0; index < lap.Track.Count; index++)
                    {
                        Trackpoint currentPoint = lap.Track[index];

                        TimeSpan elapsedTime = currentPoint.Time - startTime;

                        double? speed = null;
                        if (previousPoint != null && previousPoint.Position != null
                            && previousPoint.DistanceMeters > 0 && currentPoint.Position != null
                            && currentPoint.DistanceMeters > 0 && elapsedTime.TotalSeconds > 0)
                        {
                            double kilometersTraveled = GeoCalculation.HaversineDistance(
                                new LatLong(
                                    previousPoint.Position.LatitudeDegrees,
                                    previousPoint.Position.LongitudeDegrees),
                                new LatLong(
                                    currentPoint.Position.LatitudeDegrees,
                                    currentPoint.Position.LongitudeDegrees));
                            double hoursElapsed = (elapsedTime - (previousPoint.Time - startTime)).TotalHours;
                            speed = kilometersTraveled / hoursElapsed;
                        }

                        //double? value = lap.AverageHeartRateBpm != null ? currentPoint.HeartRateBpm?.Value : speed;
                        //if (value == null)
                        //{
                        //    previousPoint = currentPoint;
                        //    continue;
                        //}

                        //var elapsedTimeSinceLastPoint = currentPoint.Time - previousPoint.Time;
                        //EffortSpan effortSpan = effortComputer.GetSpan(value);
                        //if (!dispersion.ContainsKey(effortSpan.Threshold))
                        //{
                        //    dispersion.Add(effortSpan.Threshold, new DispersionSpan(effortSpan.Color, 0));
                        //}

                        //dispersion[effortSpan.Threshold]
                        //    .IncrementValue(elapsedTimeSinceLastPoint.TotalMilliseconds);

                        previousPoint = currentPoint;
                    }

                    return new ActivityHeaderModel(activity.ToActivityHeader(), dispersion.Values.ToList());
                });
        }

        protected async Task<List<ActivityHeaderModel>> LoadAsync()
        {
            var rides = await _dbactivityService.GetRidesAsync();
            var activities = await _tcxActivityService.GetActivitiesAsync();

            var result = new List<ActivityHeaderModel>();

            foreach (var ride in rides)
            {
                var header = await CreateHeaderViewModelAsync(ride);
                result.Add(header);
            }

            foreach (var activity in activities)
            {
                var header = await CreateHeaderViewModelAsync(activity);
                result.Add(header);
            }

            return result;
        }

        #endregion Methods

        #region Values

        protected readonly IDbActivityService _dbactivityService;
        protected readonly ITcxActivityService _tcxActivityService;

        public IMvxCommand ActivityTappedCommand { get; protected set; }

        public TaskLoaderNotifier<List<ActivityHeaderModel>> Loader { get; }

        #endregion Values
    }
}