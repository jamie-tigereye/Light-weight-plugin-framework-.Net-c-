using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWPF.AttributeDefinitions
{
    [AttributeUsage(AttributeTargets.All)]
    public class PluginVersion : Attribute, IAttribute
    {
        public int Version { get; set; }

        public PluginVersion(int version)
        {
            Version = version;
        }

        public T ToType<T>()
        {
            return (T)Convert.ChangeType(Version, typeof(T));
        }
    }
}
