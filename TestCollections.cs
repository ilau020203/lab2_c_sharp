using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;


namespace lab2
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, Tvalue>
    {
        List<TKey> editions;
        List<string> vs;
        Dictionary<TKey, Tvalue> keyValuePairsWithEdition;
        Dictionary<string, Tvalue> keyValuePairsWithString;
        private GenerateElement<TKey, Tvalue> generEl;

        public TestCollections(int n, GenerateElement<TKey, Tvalue> _generEl)
        {
            this.generEl = _generEl;
            editions = new List<TKey>(n);
            vs = new List<string>(n);
            keyValuePairsWithEdition = new Dictionary<TKey, Tvalue>();
            keyValuePairsWithString = new Dictionary<string, Tvalue>();
            for (int i = 0; i < n; i++)
            {
                var keyValuePair = _generEl(i);
                keyValuePairsWithEdition.Add(keyValuePair.Key, keyValuePair.Value);
                editions.Add(keyValuePair.Key);
                vs.Add(keyValuePair.Key.ToString());
                keyValuePairsWithString.Add(keyValuePair.Key.ToString(), keyValuePair.Value);

            }
        }
            public void SearchTList()
            {
                var first = editions[0];
                var middle = editions[editions.Count / 2];
                var last = editions[editions.Count - 1];
                var miss = generEl(editions.Count);

                var watch = Stopwatch.StartNew();

                editions.Contains(first);
                watch.Stop();
                 Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                editions.Contains(middle);
                watch.Stop();
                 Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                editions.Contains(last);
                watch.Stop();
                 Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                editions.Contains(miss.Key);
                watch.Stop();
                 Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");

            }

            public void SearchStringList()
            {
                var first = vs[0];
                var middle = vs[vs.Count / 2];
                var last = vs[vs.Count - 1];
                var miss = generEl(vs.Count);

                var watch = Stopwatch.StartNew();

                vs.Contains(first);
                watch.Stop();
                 Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                vs.Contains(middle);
                watch.Stop();
                 Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                vs.Contains(last);
                watch.Stop();
                 Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                vs.Contains(miss.Key.ToString());
                watch.Stop();
                 Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");

            }

            public void SearchTDictByKey()
            {
                var first = keyValuePairsWithEdition.ElementAt(0).Key;
                var middle = keyValuePairsWithEdition.ElementAt(vs.Count / 2).Key;
                var last = keyValuePairsWithEdition.ElementAt(keyValuePairsWithEdition.Count - 1).Key;
                var miss = generEl(keyValuePairsWithEdition.Count).Key;

                var watch = Stopwatch.StartNew();

                keyValuePairsWithEdition.ContainsKey(first);
                watch.Stop();
                 Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithEdition.ContainsKey(middle);
                watch.Stop();
                 Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithEdition.ContainsKey(last);
                watch.Stop();
                 Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithEdition.ContainsKey(miss);
                watch.Stop();
                 Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
            }

            public void SearchTDictByValue()
            {
                var first = keyValuePairsWithEdition.ElementAt(0).Value;
                var middle = keyValuePairsWithEdition.ElementAt(vs.Count / 2).Value;
                var last = keyValuePairsWithEdition.ElementAt(keyValuePairsWithEdition.Count - 1).Value;
                var miss = generEl(keyValuePairsWithEdition.Count).Value;

                var watch = Stopwatch.StartNew();

                keyValuePairsWithEdition.ContainsValue(first);
                watch.Stop();
                 Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithEdition.ContainsValue(middle);
                watch.Stop();
                 Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithEdition.ContainsValue(last);
                watch.Stop();
                 Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithEdition.ContainsValue(miss);
                watch.Stop();
                 Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
            }

            public void SearchStringDictByKey()
            {
                var first = keyValuePairsWithString.ElementAt(0).Key.ToString();
                var middle = keyValuePairsWithString.ElementAt(keyValuePairsWithString.Count / 2).Key.ToString();
                var last = keyValuePairsWithString.ElementAt(keyValuePairsWithString.Count - 1).Key.ToString();
                var miss = generEl(keyValuePairsWithString.Count).Key.ToString();

                var watch = Stopwatch.StartNew();

                keyValuePairsWithString.ContainsKey(first);
                watch.Stop();
                 Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithString.ContainsKey(middle);
                watch.Stop();
                 Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithString.ContainsKey(last);
                watch.Stop();
                 Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithString.ContainsKey(miss);
                watch.Stop();
                 Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
            }

            public void SearchStringDictByValue()
            {
                var first = keyValuePairsWithString.ElementAt(0).Value;
                var middle = keyValuePairsWithString.ElementAt(keyValuePairsWithString.Count / 2).Value;
                var last = keyValuePairsWithString.ElementAt(keyValuePairsWithString.Count - 1).Value;
                var miss = generEl(keyValuePairsWithString.Count).Value;

                var watch = Stopwatch.StartNew();

                keyValuePairsWithString.ContainsValue(first);
                watch.Stop();
                Console.WriteLine($"Search time for the first element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithString.ContainsValue(middle);
                watch.Stop();
                Console.WriteLine($"Search time for the middle element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithString.ContainsValue(last);
                watch.Stop();
                 Console.WriteLine($"Search time for the last element is {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                keyValuePairsWithString.ContainsValue(miss);
                watch.Stop();
                 Console.WriteLine($"Search time for the element that is not in the list is {watch.ElapsedMilliseconds}ms");
            }

        
    }
}
