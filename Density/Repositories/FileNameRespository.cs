using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Density
{
    public class FileNameRespository
    {
        

        public string find(string resourceFileName) { return GERString(resourceFileName); }
        private string GERString(string resourceFileName)
        {
            var stream = GetEmbeddedResourceStream(Assembly.GetCallingAssembly(), resourceFileName);
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }

        private Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)

        {
            var resourceNames = assembly.GetManifestResourceNames();
            var resourcePaths = resourceNames
                .Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase))
                .ToArray();
            return assembly.GetManifestResourceStream(resourcePaths.Single());
        }
    }
}
