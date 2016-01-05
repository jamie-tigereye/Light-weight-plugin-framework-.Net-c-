using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.AttributeDefinitions;

namespace Plugin.Plugin
{
    public class AttributeExtractor
    {
        private readonly Type _type;

        public AttributeExtractor(Type type)
        {
            _type = type;
        }

        public T GetPluginInfo<T>(Type attributeType)
        {
            var plugin = Attribute.GetCustomAttribute(_type, attributeType) as IAttribute;

            if (plugin != null)
            {
                return plugin.ToType<T>();
            }

            return default(T);
        }
    }
}
