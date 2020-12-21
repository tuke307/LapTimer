using LapTimer.Forms.UI.Functions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

using TcxTools;

namespace LapTimer.Forms.UI.Services
{
    /// <summary>
    /// TcxActivityService.
    /// </summary>
    /// <seealso cref="LapTimer.Forms.UI.Services.ITcxActivityService" />
    public class TcxActivityService : ITcxActivityService
    {
        private const string RuntasticFileFormat = "{0}.tcx";

        private readonly List<Activity> _activities = new List<Activity>();

        public async Task<List<Activity>> GetActivitiesAsync()
        {
            if (_activities.Count > 0)
            {
                return _activities;
            }

            foreach (var activityResourceName in EmbeddedResources.GetAllDomainResources())
            {
                var activity = await GetActivityByResourceName(activityResourceName);

                string[] split = activityResourceName.Split('.');
                string athlete = split[split.Length - 2].Split('_')[1];

                activity.Notes = athlete.ToUpper();
                _activities.Add(activity);
            }

            return _activities;
        }

        public Task<Activity> GetActivityAsync(string id)
        {
            return Task.Run(
                () =>
                {
                    using (var stream = EmbeddedResources.Load(string.Format(RuntasticFileFormat, id)))
                    {
                        var serializer = new XmlSerializer(typeof(TrainingCenterDatabase));
                        var @object = serializer.Deserialize(stream);

                        var database = (TrainingCenterDatabase)@object;
                        return database.Activities.Activity[0];
                    }
                });
        }

        private Task<Activity> GetActivityByResourceName(string resourceName)
        {
            return Task.Run(
                () =>
                {
                    using (var stream = EmbeddedResources.LoadWithFullName(resourceName))
                    {
                        var serializer = new XmlSerializer(typeof(TrainingCenterDatabase));
                        var @object = serializer.Deserialize(stream);

                        var database = (TrainingCenterDatabase)@object;
                        return database.Activities.Activity[0];
                    }
                });
        }
    }
}