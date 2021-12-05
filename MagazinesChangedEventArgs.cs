using System;


namespace lab2
{
    public class MagazinesChangedEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }
        public Update EventType { get; set; }
        public string MagPropName { get; set; }
        public TKey ElementKey { get; set; }
        public MagazinesChangedEventArgs(string _collectionName, Update _eventType, string _magPropName, TKey _elementKey)
        {
            CollectionName = _collectionName;
            EventType = _eventType;
            MagPropName = _magPropName;
            ElementKey = _elementKey;
        }
        public override string ToString()
        {
            return this.CollectionName + " || " + this.EventType.ToString() +
                " || " + this.MagPropName + " || " + this.ElementKey.ToString();
        }
    }

}
