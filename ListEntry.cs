using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class ListEntry
    {
        public string CollectionName { get; set; }
        public Update EventType { get; set; }
        public string MagPropertyName { get; set; }
        public string Key { get; set; }
        public ListEntry(string _collectionName, Update _eventType, string _magPropertyName, string _key)
        {
            CollectionName = _collectionName;
            EventType = _eventType;
            MagPropertyName = _magPropertyName;
            Key = _key;
        }
        public override string ToString()
        {
            return this.CollectionName + " || " + this.EventType.ToString() + " || " +
                this.MagPropertyName + " || " + this.Key;
        }
    }
}
