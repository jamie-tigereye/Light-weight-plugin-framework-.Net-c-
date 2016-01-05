using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Context
{
    public interface IContextItem
    {
        string Name { get; }
        object Value { get; }
        Type Type { get; }
    }
}
