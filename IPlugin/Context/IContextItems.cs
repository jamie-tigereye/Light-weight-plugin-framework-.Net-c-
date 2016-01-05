using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Context
{
    public interface IContextItems : IEnumerable<IContextItem>
    {
        IContextItem ItemByName(string name);
        IContextItem ItemByIndex(int index);
    }
}
    