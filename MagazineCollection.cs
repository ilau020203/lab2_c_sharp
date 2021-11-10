using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace lab2
{
    delegate TKey KeySelector<TKey>(Magazine mg);
    class MagazineCollection<TKey>
    {
        KeySelector<TKey>  keySelector;
        Dictionary<TKey,Magazine> magazines;
        public MagazineCollection(KeySelector<TKey> keySelectorvalue)
        {
            magazines = new Dictionary<TKey, Magazine>();
            keySelector = keySelectorvalue;
        }

        
        public void AddDefaults(int n)
        {
           
            if (n <= 0) throw new ArgumentException("n must be more than 0");
            for(int i = 0; i < n; i++)
            {
                Magazine magazine = new Magazine();
                TKey key = keySelector(magazine);
                magazines.Add(key,new Magazine());

            }
        }
        public Dictionary<TKey, Magazine> Magazines
        {
            get
            {
                return magazines;
            }
        }
        public void AddMagazines(params Magazine[] magazines)
        {
            foreach(Magazine magazine in magazines){
                TKey key = keySelector(magazine);
                this.magazines.Add(key, magazine);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Magazine magazine in magazines.Values)
            {
                stringBuilder.AppendLine(magazine.ToString());
            }
            return stringBuilder.ToString();
        }

        public virtual string ToShortString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Magazine magazine in magazines.Values)
            {
                stringBuilder.AppendLine(magazine.ToShortString());
            }

            return stringBuilder.ToString();
        }

        

        public double MaxRating
        {
            get
            {
                return magazines.Values.Max(t => t.MeanRating);
            }
        }

        public IEnumerable<Magazine> this[Frequency frequency]=>magazines.Values.Where((Magazine magazine)=>magazine[frequency]);
        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)=>magazines.Where(cElem => cElem.Value.Frequency == value);
        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupCollection=> magazines.GroupBy(mag => mag.Value.Frequency);
        public List<Magazine> RatingGroup(double value) => magazines.Values.Where((Magazine magazine) => magazine.MeanRating > value).ToList();
        public static string generateKey(Magazine magazine)
        {
            return magazine.ToString();
        }


    }
}
