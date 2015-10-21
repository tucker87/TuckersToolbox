using System;
using System.Collections.Generic;

namespace TuckersToolbox
{
    public class MultiKeyDictionary<TKey1, TKey2, TValue> : Dictionary<TKey1, TValue>
    {
        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> _innerDictionary;

        public MultiKeyDictionary()
        {
            _innerDictionary = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            _innerDictionary.Add(new Tuple<TKey1, TKey2>(key1, key2), value);
        }

        private TValue GetValue(TKey1 key1, TKey2 key2)
        {
            return _innerDictionary[new Tuple<TKey1, TKey2>(key1, key2)];
        }

        private void SetValue(TKey1 key1, TKey2 key2, TValue value)
        {
            _innerDictionary[new Tuple<TKey1, TKey2>(key1, key2)] = value;
        }

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return GetValue(key1, key2); }
            set { SetValue(key1, key2, value); }
        }
    }
}
