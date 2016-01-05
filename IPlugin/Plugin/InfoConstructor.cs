using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.AttributeDefinitions;
using Plugin;

namespace Plugin.Plugin
{
    internal class InfoConstructor
    {
        private readonly Type _type;
        private readonly AttributeExtractor _extractor;

        public InfoConstructor(Type type)
        {
            _type = type;
            _extractor = new AttributeExtractor(type);
        }

        public IPluginInfo GetPluginInfo()
        {
            var info = new PluginInfo
            {
                Name = _extractor.GetPluginInfo<string>(typeof (PluginName)),
                DateCreated = _extractor.GetPluginInfo<DateTime>(typeof (PluginDateCreated)),
                Version = _extractor.GetPluginInfo<int>(typeof (PluginVersion)),
                Type = _type
            };

            return info;
        }
    }
}
