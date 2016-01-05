using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plugin
{
    public interface IPluginInfo
    {
        string Name { get; set; }
        int Version { get; set; }
        DateTime DateCreated { get; set; }
        Type Type { get; set; }
    }
}
