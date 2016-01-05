using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWPF.AttributeDefinitions
{
    [AttributeUsage(AttributeTargets.All)]
    public class PluginName : Attribute, IAttribute
    {
        public string Name { get; set; }

        public PluginName(string name)
        {
            Name = name;
        }

        public T ToType<T>()
        {
            return (T)Convert.ChangeType(Name, typeof(T));
        }
    }
}
