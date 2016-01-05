using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LWPF.Plugin;

namespace LWPF.Enumerator
{
    /// <summary>
    /// Enumerates through plug-in within file or directory path of specified interface type.
    /// Plug-ins can be filtered by plug-in information by passing in the filter as an IPluginInfo
    /// predicate to the constructor.
    /// </summary>
    /// <typeparam name="T">Common interface type between plug-ins</typeparam>
    public class Plugins<T> : IEnumerable<PluginKeyValuePair<T>> where T: class, IPlugin
    {
        private readonly List<FileInfo> _fileInfo;
        private readonly Func<IPluginInfo, bool> _pluginInfoPredicate;
        private readonly PluginFetcher<T> _pluginFetcher; 


        // Constructor takes in file path as FileInfo object, as well as an optional IPluginInfo predicate
        public Plugins(FileInfo fileInfo, Func<IPluginInfo, bool> pluginInfoPredicate = null)
        {
            // Populates file list with a list with just the one file that was passed to the constructor
            _fileInfo = new List<FileInfo> {fileInfo};

            _pluginInfoPredicate = pluginInfoPredicate;
            _pluginFetcher = new PluginFetcher<T>();
        }

        // Constructor takes in directory path as DirectoryInfo object, as well as an optional IPluginInfo predicate
        public Plugins(DirectoryInfo directoryInfo, Func<IPluginInfo, bool> pluginInfoPredicate = null)
        {
            // Populates file list with a list of all files within the directory passed to the constructor
            _fileInfo.AddRange(directoryInfo.EnumerateFiles());

            _pluginInfoPredicate = pluginInfoPredicate;
        }
        
        public IEnumerator<PluginKeyValuePair<T>> GetEnumerator()
        {
            return GetPlugins().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Enumerates plug-ins within all file within file list
        private IEnumerable<PluginKeyValuePair<T>> GetPlugins()
        {
            foreach (var file in _fileInfo)
            {
                foreach (var plugin in _pluginFetcher.GetPluginTypes(file.FullName))
                {
                    var pluginInfo = new InfoConstructor(plugin).GetPluginInfo();
                    
                    if (_pluginInfoPredicate.Invoke(pluginInfo))
                    {
                        yield return new PluginKeyValuePair<T>(pluginInfo);
                    }
                }
            }
        }
    }
}
