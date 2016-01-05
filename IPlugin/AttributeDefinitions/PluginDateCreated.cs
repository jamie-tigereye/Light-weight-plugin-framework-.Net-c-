using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWPF.AttributeDefinitions
{
    [AttributeUsage(AttributeTargets.All)]
    public class PluginDateCreated : Attribute, IAttribute
    {
        public DateTime DateCreated { get; set; }

        public PluginDateCreated(DateTime dateCreated)
        {
            DateCreated = dateCreated;
        }

        public PluginDateCreated(string dateCreated)
        {
            DateTime creationDate;
            DateTime.TryParse(dateCreated, out creationDate);
            DateCreated = creationDate;
        }

        public T ToType<T>()
        {
            return(T)Convert.ChangeType(DateCreated, typeof(T));
        }
    }
}
