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




            KeySelector<string> selector = delegate (Magazine input)
            {
                return (input.GetHashCode().ToString());
            };
            MagazineCollection<string> OneCollection = new MagazineCollection<string>(selector);
            MagazineCollection<string> TwoCollection = new MagazineCollection<string>(selector);
            OneCollection.CollectionName = "OneCollection";
            TwoCollection.CollectionName = "TwoCollection";
            Listener listener = new Listener();
            OneCollection.MagazinesChanged += listener.newListEntry;
            TwoCollection.MagazinesChanged += listener.newListEntry;
            Magazine OneMagazine = new Magazine("One Title", Frequency.Yearly, new DateTime(), 131);
            Magazine TwoMagazine = new Magazine("Two Title", Frequency.Monthly, new DateTime(2001, 10, 12), 122);
            Magazine ThreeMagazine = new Magazine("Three Title", Frequency.Yearly, new DateTime(1999, 6, 6), 133);
            Magazine FourMagazine = new Magazine("Four Title", Frequency.Monthly, new DateTime(2021, 1, 4), 432);
            Magazine FiveMagazinee = new Magazine("Five Title", Frequency.Yearly, new DateTime(2021, 2, 9), 434);
            Magazine SixMagazine = new Magazine("Six Title", Frequency.Weekly, new DateTime(2025, 3, 7), 999);
            Magazine SevenMagazine = new Magazine("Seven Title", Frequency.Yearly, new DateTime(2021, 1, 1), 1134);
            OneCollection.AddMagazines(OneMagazine, TwoMagazine);
            TwoCollection.AddMagazines(ThreeMagazine, FourMagazine, SevenMagazine);
            TwoCollection.AddDefaults();
            OneMagazine.Circulation = 1234;
            ThreeMagazine.Circulation = 4321;
            OneCollection.Replace(OneMagazine, FiveMagazinee);
            TwoCollection.Replace(ThreeMagazine, SixMagazine);
            ThreeMagazine.Circulation = 1001;
            FiveMagazinee.ReleaseDate = new DateTime();
            FiveMagazinee.Frequency = Frequency.Weekly;
            SixMagazine.Frequency = Frequency.Yearly;

            Console.WriteLine(listener.ToString());

            ////1
            //List<Magazine> magazineList=new List<Magazine>();
            //magazineList.Add(new Magazine("Horroh stories inc.", Frequency.Monthly, DateTime.Now, 100000));
            //magazineList.Add(new Magazine("aHorroh stories inc.", Frequency.Monthly, new DateTime(2001, 1, 1), 144400000));
            //magazineList.Add(new Magazine("Horroh stories inc.", Frequency.Monthly, new DateTime(2001, 1, 1), 100000));
            //magazineList.Add(new Magazine("Horroh stories inc.", Frequency.Monthly, DateTime.Now, 144400000));
            //magazineList.Add(new Magazine("aHorroh stories inc", Frequency.Dayly, DateTime.Now, 100000));

            //foreach(Magazine magazine in magazineList)
            //{
            //    magazine.AddArticles(new Article());
            //}
            //magazineList[0].AddArticles(new Article(new Person(), "asdf", 3425));
            //magazineList.Sort();
            //foreach (Magazine magazine in magazineList)
            //{
            //    Console.WriteLine(magazine.ToShortString());
            //}
            //magazineList.Sort((new Magazine()).Compare);
            //foreach (Magazine magazine in magazineList)
            //{
            //    Console.WriteLine(magazine.ToShortString());
            //}
            //magazineList.Sort(new CirculationComparer());
            //foreach (Magazine magazine in magazineList)
            //{
            //    Console.WriteLine(magazine.ToShortString());
            //}


            ////2------------------
            //Console.WriteLine("\n\nPart 2\n\n");
            //KeySelector<String> selector = delegate (Magazine magazine) { return magazine.GetHashCode().ToString(); };
            //MagazineCollection<String> mgCollection = new MagazineCollection<string>(selector);
            //mgCollection.AddDefaults(3);
            //mgCollection.AddMagazines(new Magazine("aHorroh stories inc.", Frequency.Monthly, new DateTime(2001, 1, 1), 144400000));
            //Console.WriteLine(mgCollection.ToShortString());
            /////3----------------
            //Console.WriteLine(mgCollection.MaxRating);


            //var mgGroups = mgCollection.FrequencyGroup(Frequency.Monthly);
            //Console.WriteLine("Magazine with monthly output frequency: ");
            //foreach (var keyValuePair in mgGroups)
            //{
            //    Console.WriteLine(keyValuePair.Value);
            //}


            //foreach (var item in mgCollection.GroupCollection)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine();
            //    foreach (var name in item)
            //    {
            //        Console.WriteLine(name);
            //    }
            //}


            ////4----------------------------
            //int size = -1;
            //Console.Write("Size of collection: ");
            //Console.ResetColor();
            //while (!int.TryParse(Console.ReadLine(), out size) || size < 0)
            //{
            //    Console.WriteLine("Incorrect number, try again:");
            //    Console.ResetColor();
            //}

            //GenerateElement<Edition, Magazine> generatorFunc = delegate (int j)
            //{
            //    try
            //    {
            //        var key = new Edition("Edition" + j.ToString(), new DateTime(j % 9999 + 1, (j % 12) + 1, 1 + (j % 28)), j * j);
            //        var value = new Magazine( "Mag" + j.ToString(), (Frequency)(j % 3), new DateTime(j % 9999 + 1, 1 + j % 12, 1 + j % 28), j);
            //        return new KeyValuePair<Edition, Magazine>(key, value);

            //    }
            //    catch (Exception e)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine(j);
            //        Console.WriteLine(e);
            //        throw;
            //    }

            //};
            //TestCollections<Edition, Magazine>
            //    collections = new TestCollections<Edition, Magazine>(size, generatorFunc);
            //Console.WriteLine("String List:");
            //collections.SearchStringList();
            //Console.WriteLine("____________________________________________");
            //Console.WriteLine("TList");
            //collections.SearchTList();
            //Console.WriteLine("____________________________________________");
            //Console.WriteLine("String dict by key");
            //collections.SearchStringDictByKey();
            //Console.WriteLine("____________________________________________");
            //Console.WriteLine("String dict by value");
            //collections.SearchStringDictByValue();
            //Console.WriteLine("____________________________________________");
            //Console.WriteLine("TDict by key");
            //collections.SearchTDictByKey();
            //Console.WriteLine("____________________________________________");
            //Console.WriteLine("TDict by value");
            //collections.SearchTDictByValue();
        }
    }
}
