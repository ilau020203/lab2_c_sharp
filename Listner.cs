using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    public class Listener
    {
        private List<ListEntry> list = new List<ListEntry>();
        public void newListEntry(object obj, MagazinesChangedEventArgs<string> args)
        {
            list.Add(new ListEntry(args.CollectionName, args.EventType, args.MagPropName, args.ElementKey));
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in list)
            {
                s += item.ToString() + "\n";
            }
            return s;
        }
    }
}

