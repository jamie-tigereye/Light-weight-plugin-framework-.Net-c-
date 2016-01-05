using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWPF.AttributeDefinitions;
using LWPF.Context;
using LWPF.Enumerator;
using LWPF.Plugin;
using Example.SharedInterfaces;

namespace Example.Loader
{
    class Loader
    {
        public void RunExample()
        {
            var plugins = LoadAllSamplePluginsWithin("C:\\some\\path");

            foreach (var plugin in plugins)
            {
                Console.WriteLine(plugin.GetSomething());
            }
        }

        // Loads all sample plugins created before yesterday from specified directory
        public IEnumerable<ISamplePlugin> LoadAllSamplePluginsWithin(string directory)
        {
            // Create directory info instance from directory path
            var path = new DirectoryInfo(directory);

            // Create a context item collection
            ICollection<IContextItem> contextItems = new ContextItems();

            // Add some context objects
            contextItems.Add(new ContextItem("HelloWorldObject", "Hello World !!!"));

            // Enumerate through all plugins with attribute info that match an example predicate
            foreach (var plugin in new Plugins<ISamplePlugin>(path, x => x.DateCreated > DateTime.Now))
            {
                // Yield return instance of enumerable plugin with injected context
                yield return plugin.GetInitialisedPlugin((IContextItems)contextItems);
            }
        }
    }
}
