using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Variant5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var text = new[]
            {
                "Текст. представлен. в виде массива строк, слова в которых; разделены: пробелами-и знаками",
                "Новый, массив; должен содержать не: более- n таких слов. Все слова должны быть в нижнем регистре."
            };

            var words = GetLongestWords(text, 5);
            foreach (var word in words)
                Console.WriteLine(word);

            var strs = File.ReadAllLines("db.txt");
            var dataBase = new List<Record>();

            foreach (var str in strs)
            {
                var data = str.Split();

                var record = new Record()
                {
                    ClientID = int.Parse(data[0]),
                    Year = int.Parse(data[1]),
                    Month = int.Parse(data[2]),
                    Duration = int.Parse(data[3])
                };

                dataBase.Add(record);
            }

            PrintYearsLongestDurationOfMonth(dataBase, 2);
            Console.ReadKey();
        }

        public static string[] GetLongestWords(string[] lines, int n)
        {
            return lines.SelectMany(x => x.Split(new[] {'-', ':', ',', '.', ' ', ';'}))
                .OrderBy(x => x)
                .ThenByDescending(x => x.Length)
                .Take(n)
                .ToArray();
        }

        public static void PrintYearsLongestDurationOfMonth(List<Record> data, int id)
        {
            var years = data.Where(x => x.ClientID == id)
                .GroupBy(x => x.Year)
                .Select(x => (x.Max(y => (y.Duration, y.Month)), x.Key))
                .OrderByDescending(x => x.Key)
                .ToArray();
            if (years.Length > 0)
            {
                foreach (var year in years)
                {
                    Console.WriteLine(
                        $"Год: {year.Key}, месяц: {year.Item1.Month}, продолжительность: {year.Item1.Duration}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о клиенте");
            }
        }
    }
}