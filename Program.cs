using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab2
{
    class Program
    {
        static void Main(string[] _args)
        {
            //1
            List<Magazine> magazineList=new List<Magazine>();
            magazineList.Add(new Magazine("Horroh stories inc.", Frequency.Monthly, DateTime.Now, 100000));
            magazineList.Add(new Magazine("aHorroh stories inc.", Frequency.Monthly, new DateTime(2001, 1, 1), 144400000));
            magazineList.Add(new Magazine("Horroh stories inc.", Frequency.Monthly, new DateTime(2001, 1, 1), 100000));
            magazineList.Add(new Magazine("Horroh stories inc.", Frequency.Monthly, DateTime.Now, 144400000));
            magazineList.Add(new Magazine("aHorroh stories inc", Frequency.Dayly, DateTime.Now, 100000));
          
            foreach(Magazine magazine in magazineList)
            {
                magazine.AddArticles(new Article());
            }
            magazineList[0].AddArticles(new Article(new Person(), "asdf", 3425));
            magazineList.Sort();
            foreach (Magazine magazine in magazineList)
            {
                Console.WriteLine(magazine.ToShortString());
            }
            magazineList.Sort((new Magazine()).Compare);
            foreach (Magazine magazine in magazineList)
            {
                Console.WriteLine(magazine.ToShortString());
            }
            magazineList.Sort(new CirculationComparer());
            foreach (Magazine magazine in magazineList)
            {
                Console.WriteLine(magazine.ToShortString());
            }


            //2------------------
            Console.WriteLine("\n\nPart 2\n\n");
            KeySelector<String> selector = delegate (Magazine magazine) { return magazine.GetHashCode().ToString(); };
            MagazineCollection<String> mgCollection = new MagazineCollection<string>(selector);
            mgCollection.AddDefaults(3);
            mgCollection.AddMagazines(new Magazine("aHorroh stories inc.", Frequency.Monthly, new DateTime(2001, 1, 1), 144400000));
            Console.WriteLine(mgCollection.ToShortString());
            ///3----------------
            Console.WriteLine(mgCollection.MaxRating);


            var mgGroups = mgCollection.FrequencyGroup(Frequency.Monthly);
            Console.WriteLine("Magazine with monthly output frequency: ");
            foreach (var keyValuePair in mgGroups)
            {
                Console.WriteLine(keyValuePair.Value);
            }


            foreach (var item in mgCollection.GroupCollection)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine();
                foreach (var name in item)
                {
                    Console.WriteLine(name);
                }
            }


            //4----------------------------
            int size = -1;
            Console.Write("Size of collection: ");
            Console.ResetColor();
            while (!int.TryParse(Console.ReadLine(), out size) || size < 0)
            {
                Console.WriteLine("Incorrect number, try again:");
                Console.ResetColor();
            }

            GenerateElement<Edition, Magazine> generatorFunc = delegate (int j)
            {
                try
                {
                    var key = new Edition("Edition" + j.ToString(), new DateTime(j % 9999 + 1, (j % 12) + 1, 1 + (j % 28)), j * j);
                    var value = new Magazine( "Mag" + j.ToString(), (Frequency)(j % 3), new DateTime(j % 9999 + 1, 1 + j % 12, 1 + j % 28), j);
                    return new KeyValuePair<Edition, Magazine>(key, value);

                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(j);
                    Console.WriteLine(e);
                    throw;
                }

            };
            TestCollections<Edition, Magazine>
                collections = new TestCollections<Edition, Magazine>(size, generatorFunc);
            Console.WriteLine("String List:");
            collections.SearchStringList();
            Console.WriteLine("____________________________________________");
            Console.WriteLine("TList");
            collections.SearchTList();
            Console.WriteLine("____________________________________________");
            Console.WriteLine("String dict by key");
            collections.SearchStringDictByKey();
            Console.WriteLine("____________________________________________");
            Console.WriteLine("String dict by value");
            collections.SearchStringDictByValue();
            Console.WriteLine("____________________________________________");
            Console.WriteLine("TDict by key");
            collections.SearchTDictByKey();
            Console.WriteLine("____________________________________________");
            Console.WriteLine("TDict by value");
            collections.SearchTDictByValue();
        }
    }
}
