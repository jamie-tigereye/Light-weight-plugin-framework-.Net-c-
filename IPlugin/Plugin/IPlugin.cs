using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Context;

namespace Plugin.Plugin
{
    public interface IPlugin
    {
        void Initialise(IContextItems contextItems);
        IContextItems ContextItems { get; }
    }
}
