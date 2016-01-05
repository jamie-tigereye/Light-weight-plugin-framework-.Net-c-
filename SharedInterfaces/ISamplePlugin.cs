using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWPF.Plugin;

namespace Example.SharedInterfaces
{
    public interface ISamplePlugin : IPlugin
    {
        string GetSomething();
    }
}
