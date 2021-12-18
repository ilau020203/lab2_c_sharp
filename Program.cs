using System;
using System.Collections.Generic;
using System.IO;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Task 1");
            Magazine magazine = new Magazine("First Magazine", Frequency.Dayly, new DateTime(2021, 12, 17), 111);
            List<Article> articles = new List<Article>();
            articles.Add(new Article(new Person("Ivan", "Ivanov", new DateTime(2001, 10, 22)), "latest article", 44.2));
            articles.Add(new Article(new Person("Petr", "Smirnov", new DateTime(2001, 2, 3)), "lala", 355.6));
            articles.Add(new Article(new Person("Vladimir", "Petrov", new DateTime(2001, 9, 11)), "oi ty travyshka zelenay", 1228.9));
            magazine.AddArticles(articles);
            Magazine copy =(Magazine) magazine.DeepCopy();
            Console.WriteLine("Исходный объект: "); Console.WriteLine(magazine.ToString());
            Console.WriteLine("Копия: "); Console.WriteLine(copy.ToString());
            Console.WriteLine("\nTask 2");
            Console.Write("Введите название файла: ");
            string filename = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(filename);
            Magazine mag = new Magazine();
            if (fileInfo.Exists)
            {
                mag.Load(filename);
            }
            else
            {
                Console.WriteLine("Данного файла не существует. Создаем...");
                fileInfo.Create();
            }
            Console.WriteLine("\nTask 3");
            Console.WriteLine(mag.ToString());
            Console.WriteLine("\nTask 4");
            mag.AddFromConsole();
            mag.Save(filename);
            Console.WriteLine(mag.ToString());
            Console.WriteLine("\nTask 5");
            Magazine.Load(filename, ref mag);
            mag.AddFromConsole();
            Magazine.Save(filename, mag);
            Console.WriteLine("\nTask 6");
            Console.WriteLine(mag.ToString());
            
        }
    }
}
