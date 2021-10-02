using System;
using System.Diagnostics;
using System.Linq;

namespace lab2
{
    class Program
    {
        static void Main(string[] _args)
        {
            Console.WriteLine($"{Environment.NewLine}1");
            Edition first = new Edition("model", new DateTime(1, 1, 1), 100);
            Console.WriteLine($"First edition: {first}");
            Edition second = new Edition("model", new DateTime(1, 1, 1), 100);
            Console.WriteLine($"Second Edition (same as first) {second}");
            Console.WriteLine($"Reference equality: {first as object == second as object}");
            Console.WriteLine($"Value equality: {first == second}");

            Console.WriteLine($"{Environment.NewLine}2");
            try
            {
                first.Circulation = -100;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }

            Console.WriteLine($"{Environment.NewLine}3");
            Magazine mag = new Magazine("Horroh stories inc.", Frequency.Monthly, DateTime.Now, 100000);
            mag.AddArticles(
                new Article(
                    new Person(
                        "Frank",
                        "James",
                        new DateTime(1990, 1, 2)
                    ),
                    "Horror story 1",
                    50.0
                ),
                new Article(
                    new Person(
                        "Frank",
                        "James",
                        new DateTime(1990, 1, 2)
                    ),
                    "Horror story 2",
                    70.0
                ),
                new Article(
                    new Person(
                        "Frank",
                        "James",
                        new DateTime(1990, 1, 2)
                    ),
                    "Horror story 3",
                    90.0
                ),
                new Article(
                    new Person(
                        "Dmitriy",
                        "Pupkin",
                        new DateTime(1980, 3, 4)
                    ),
                    "Scary story 1",
                    10.0
                ),
                new Article(
                    new Person(
                        "Dmitriy",
                        "Pupkin",
                        new DateTime(1980, 3, 4)
                    ),
                    "Scary story 2",
                    20.0
                ),
                new Article(
                    new Person(
                        "Dmitriy",
                        "Pupkin",
                        new DateTime(1980, 3, 4)
                    ),
                    "Scary story 1 REMAKE",
                    10.0
                ), new Article(
                    new Person(
                    "Vladimir",
                    "Vladimirovich",
                    new DateTime(1952, 10, 7)
                ),
                    "Scary story 1 REMAKE",
                    10.0
                )
            );
            mag.AddEditors(
                new Person(
                    "Vladimir",
                    "Vladimirovich",
                    new DateTime(1952, 10, 7)
                ),
                new Person(
                    "Ramzan",
                    "Achmatovich",
                    new DateTime(1976, 10, 5)
                )
            );
            Console.WriteLine(mag.ToString());

            Console.WriteLine($"{Environment.NewLine}4");
            Console.WriteLine($"Magazine as Editiion: {mag as Edition}");

            Console.WriteLine($"{Environment.NewLine}5");
            Magazine mag_copy = (Magazine)mag.DeepCopy();
            Console.WriteLine($"First magazine: {mag}");
            Console.WriteLine($"Second magazine: {mag_copy}");

            Console.WriteLine($"{Environment.NewLine}6");
            //String.Join() Has foreach in its realization
            Console.WriteLine($"Articles with Rating More than 50 from second magazine: {String.Join(Environment.NewLine, mag_copy.ArticlesWithRatingHigherThan(50.0))}");

            Console.WriteLine($"{Environment.NewLine}7");
            Console.WriteLine($"Second part of each article series: {String.Join(Environment.NewLine, mag_copy.ArticlesWithNameContaining("2"))}");

            Console.WriteLine($"{Environment.NewLine}8");
            Console.WriteLine($"Articles with Authors not in Editors list: {{");
            foreach (Article article in mag_copy)
            {
                foreach (
                    string line in article.ToString().Split(Environment.NewLine))
                {
                    Console.WriteLine($"  {line}");
                }
            }
            Console.WriteLine($"}}{Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}9");
            Console.WriteLine($"Articles with Authors in Editors list: {{");
            foreach (Article article in mag_copy.ArticlesWithAuthorSameAsEditor())
            {
                foreach (
                    string line in article.ToString().Split(Environment.NewLine))
                {
                    Console.WriteLine($"  {line}");
                }
            }
            Console.WriteLine($"}}{Environment.NewLine}");

            Console.WriteLine($"{Environment.NewLine}10");
            Console.WriteLine($"Editors within authors list: {{");
            foreach (Person author in mag_copy.EditorsWithNoArticles())
            {
                foreach (
                    string line in author.ToString().Split(Environment.NewLine))
                {
                    Console.WriteLine($"  {line}");
                }
            }
            Console.WriteLine($"}}{Environment.NewLine}");

            String something =null;
            Person one = new Person(
                        "Dmitriy",
                        "Pupkin",
                        new DateTime(1980, 3, 4)
                    );
            one.Equals(something);
        }
    }
}
