using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWPF.Context;
using LWPF;

namespace LWPF.Plugin
{
    public abstract class AbstractPlugin : IPlugin
    {
        public IContextItems ContextItems { get; private set; }
        
        public void Initialise(IContextItems contextItems)
        {
            ContextItems = contextItems;
        }
    }

}
