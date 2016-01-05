using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.SharedInterfaces;
using LWPF.AttributeDefinitions;

namespace Example.Plugin
{
    [PluginName("My sample plugin")]
    [PluginVersion(32)]
    [PluginDateCreated("11/01/1989")]
    public class MySamplePlugin : LWPF.Plugin.AbstractPlugin
    {
        // A simple example plugin that returns an item back from the context
        // In reality a plugin is likely to use such context data to perform
        // a process and return the result.

        public MySamplePlugin()
        {
            
        }

        public string GetSomething()
        {
            var contextItem = ContextItems.ItemByName("HelloWorldObject");

            if (contextItem.Type == typeof (string))
            {
                return string.Format("My sample plug-in returns - {0}", (string)contextItem.Value);
            }

            return null;
        }
    }
}
