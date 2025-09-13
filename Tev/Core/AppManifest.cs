using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tev.Core;

public sealed class AppManifest
{
    public string? Name { get; set; }
    public string? AppPath { get; set; }
    public string? AppAuthor { get; set; }
    public string? AppVersion { get; set; }
    public string? AppIconPath { get; set; }
    public string? AppFolder { get; set; }
    //public string? AuthKey { get; set; }
}
