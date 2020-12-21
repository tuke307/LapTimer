using LapTimer.Forms.UI.Themes;
using SkiaSharpnado.Maps.Domain;
using System.Collections.Generic;

namespace LapTimer.Forms.UI.Models
{
    public static class HumanEffortComputer
    {
        public static EffortComputer BySpeed { get; }

        static HumanEffortComputer()
        {
            BySpeed = new EffortComputer(
                new List<EffortSpan>
                    {
                        new EffortSpan(0f, ResourcesHelper.GetResourceColor("ColorEffortSpeedMin"), /*Functions.Resources.GetLocalisedRes(typeof(Resx.resources),nameof(Resx.resources.PaceVeryLight)*/"VERY LIGHT"),
                        new EffortSpan(0.7f, ResourcesHelper.GetResourceColor("ColorEffortAnaerobic"), /*Functions.Resources.GetLocalisedRes(typeof(Resx.resources),nameof(Resx.resources.PaceAnaerobic)*/"ANAEROBIC"),
                        new EffortSpan(0.95f, ResourcesHelper.GetResourceColor("ColorEffortMax"), /*Functions.Resources.GetLocalisedRes(typeof(Resx.resources),nameof(Resx.resources.PaceMax)*/"MAX"),
                    },
                40);
        }
    }
}