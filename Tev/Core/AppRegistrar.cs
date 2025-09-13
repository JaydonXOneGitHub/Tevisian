using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tev.Core;

public static class AppRegistrar
{
    public static Dictionary<string, AppManifest?>? Search(string dir)
    {
        Dictionary<string, AppManifest?> manifests = [];

        if (!Directory.Exists(dir))
        {
            return manifests;
        }

        string[] subdirs = Directory.GetDirectories(dir);

        foreach (string subdir in subdirs)
        {
            Console.WriteLine(subdir);

            string file = Path.Combine(
                subdir,
                "appmanifest.json"
            );

            Console.WriteLine(file);

            if (!File.Exists(file))
            {
                continue;
            }

            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                var am = JsonSerializer.Deserialize(fs, AppManifestSerializeContext.Default.AppManifest);

                manifests.Add(subdir, am);
            }
        }

        manifests.TrimExcess();

        // Called explicitly,
        // so that I won't have to worry about
        // extra memory being taken up
        // by the strings potentially generated
        // by this process.
        GC.Collect();

        return manifests;
    }
}
