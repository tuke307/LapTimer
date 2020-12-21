using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LapTimer.Forms.UI.Functions
{
    internal static class EmbeddedResources
    {
        private static readonly Assembly Assembly;

        private static readonly string[] Resources;

        static EmbeddedResources()
        {
            Assembly = typeof(EmbeddedResources).GetTypeInfo().Assembly;
            Resources = Assembly.GetManifestResourceNames();
        }

        public static bool Exists(string name)
        {
            name = $".Resources.{name}";
            name = Resources.FirstOrDefault(n => n.EndsWith(name));
            return name != null;
        }

        public static IEnumerable<string> GetAllDomainResources()
        {
            const string name = "Domain.Resources";
            return Resources.Where(n => n.Contains(name)).OrderBy(n => n);
        }

        public static Stream Load(string name)
        {
            name = Resources.FirstOrDefault(n => n.EndsWith(name));

            Stream stream = null;
            if (name != null)
            {
                stream = Assembly.GetManifestResourceStream(name);
            }

            return stream;
        }

        public static Stream LoadWithFullName(string resourceFullName)
        {
            return Assembly.GetManifestResourceStream(resourceFullName); ;
        }
    }
}