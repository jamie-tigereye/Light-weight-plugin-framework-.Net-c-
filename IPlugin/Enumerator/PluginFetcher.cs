using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LWPF.Enumerator
{
    internal class PluginFetcher<T>
    {
        public PluginFetcher()
        {
            AppDomain.CurrentDomain.AssemblyResolve +=
                (sender, args) => Assembly.LoadFile(args.Name);

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve +=
                (sender, args) => Assembly.ReflectionOnlyLoad(args.Name);
        }

        public List<Type> GetPluginTypes(string path)
        {
            var nextAssembly = Assembly.LoadFile(path);

            var types = new List<Type>();

            foreach (var type in nextAssembly.GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(T)))
                {
                    types.Add(type);
                }
            }

            return types;
        }
    }
}
