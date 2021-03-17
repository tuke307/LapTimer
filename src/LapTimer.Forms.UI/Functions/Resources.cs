using System;
using System.Globalization;
using System.Resources;

namespace LapTimer.Forms.UI.Functions
{
    public static class Resources
    {
        public static string GetLocalisedRes(Type resType, string resourceNameKey)
        {
            string translate = string.Empty;

            try
            {
                ResourceManager rm = new ResourceManager(resType);
                translate = rm.GetString(resourceNameKey, CultureInfo.CurrentCulture);
            }
            catch
            {
                translate = string.Empty;
            }
            return translate;
        }
    }
}