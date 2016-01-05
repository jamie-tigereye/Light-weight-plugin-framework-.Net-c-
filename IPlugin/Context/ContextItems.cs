using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWPF;

namespace LWPF.Context
{
    public class ContextItems : ICollection<IContextItem>, IContextItems
    {
        private readonly Dictionary<string, IContextItem> _contextItems;

        public ICollection<string> Keys
        {
            get { return _contextItems.Keys; }
        }

        public ICollection<IContextItem> Values
        {
            get { return _contextItems.Values; }
        }

        public int Count
        {
            get { return _contextItems.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        
        public IContextItem this[string key]
        {
            get { return _contextItems[key]; }

            set { _contextItems[key] = value; }
        }

        public ContextItems()
        {
            _contextItems = new Dictionary<string, IContextItem>();
        }

        public IContextItem ItemByName(string name)
        {
            return _contextItems[name];
        }

        public IContextItem ItemByIndex(int index)
        {
            var itemCount = 1;
            foreach (var contextItem in _contextItems.Values)
            {
                itemCount++;
                if (itemCount == index) return contextItem;
            }

            return null;
        }

        public IEnumerator<IContextItem> GetEnumerator()
        {
            foreach (var item in _contextItems)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(string key)
        {
            return _contextItems.ContainsKey(key);
        }

        public void Add(IContextItem contextItem)
        {
            _contextItems.Add(contextItem.Name, contextItem);
        }

        public bool Remove(string key)
        {
            return _contextItems.Remove(key);
        }

        public bool TryGetValue(string key, out IContextItem value)
        {
            return _contextItems.TryGetValue(key, out value);
        }
        
        public void Clear()
        {
            _contextItems.Clear();
        }

        public bool Contains(IContextItem contextItem)
        {
            return _contextItems.ContainsValue(contextItem);
        }
        
        public bool Remove(IContextItem contextItem)
        {
            return _contextItems.Remove(contextItem.Name);
        }

        public void CopyTo(IContextItem[] array, int arrayIndex)
        {
            _contextItems.Values.CopyTo(array, arrayIndex);
        }
    }
}
