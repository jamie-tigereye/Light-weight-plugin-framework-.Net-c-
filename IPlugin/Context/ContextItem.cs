using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;

namespace Plugin.Context
{
    public class ContextItem : IContextItem
    {
        public string Name { get; }
        public object Value { get; }
        public Type Type { get; }

        public ContextItem(string name, object value)
        {
            Name = name;
            Value = value;
            Type = value.GetType();
        }
    }
}
