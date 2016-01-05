using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.AttributeDefinitions;

namespace Plugin.Plugin
{
    internal class PluginInfo : IPluginInfo
    {
        public PluginInfo()
        {
            
        }

        public virtual string Name { get; set; }
        public virtual int Version { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual Type Type { get; set; }
    }
}
