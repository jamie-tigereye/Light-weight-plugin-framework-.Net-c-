using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.AttributeDefinitions;

namespace Plugin.Plugin
{
    public class PluginKeyValuePair<T> where T : IPlugin
    {
        public IPluginInfo PluginInfo { get; }

        public PluginKeyValuePair(IPluginInfo pluginInfo)
        {
            PluginInfo = pluginInfo;
        }
        
        public T GetInitialisedPlugin(IContextItems contextItems)
        {
            var plugin = (T)Activator.CreateInstance(PluginInfo.Type);
            plugin.Initialise(contextItems);
            return plugin;
        }
    }
}
