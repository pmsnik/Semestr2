using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Variant5
{
    internal class Program
    {
        public static void Main()
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

        /*
         * Текст представлен в виде массива строк, слова в которых разделены пробелами и знаками препинания (переносов
         * нет). Написать метод, который по заданному тексту и целому числу n возвращает массив из различных слов
         * наибольшей длины, упорядоченных в порядке убывания длины (слова одинаковой длины должны идти в алфавитном
         * порядке). Новый массив должен содержать не более n таких слов. Все слова должны быть в нижнем регистре. Метод
         * должен быть написан с использованием только одного оператора.
         */
        public static string[] GetLongestWords(string[] lines, int n)
        {
            return lines
                .SelectMany(x => x.Split(new[] {'-', ':', ',', '.', ' ', ';'}, StringSplitOptions.RemoveEmptyEntries))
                // Из задания трудно понять каким именно образом возвращать все слова в нижнем регистре
                // Это фильтрация всех слов по нижнему регистру
                .Where(x => x == x.ToLower())
                // Это перевод всех слов в нижний регистр
                //.Select(x => x.ToLower())
                .OrderByDescending(x => x.Length)
                .ThenBy(x => x)
                .Take(n)
                .ToArray();
        }

        
        /*
         * Написать метод, который по заданному коду клиента для каждого года, в котором этот клиент посещал центр,
         * определяет месяц, в котором продолжительность занятий данного клиента была наибольшей для данного года
         * (если таких месяцев несколько, то выбирать месяц с наименьшим номером), а затем сведения о каждом годе
         * выводит на консоль построчнов следующем порядке: год, номер месяца, продолжительность занятий в этом месяце
         * (упорядочивать сведения по убыванию номера года). Если данные о клиенте c заданным кодом отсутствуют, метод
         * должен вывести сообщение об отсутствии данных для данного клиента.
         */
        public static void PrintYearsLongestDurationOfMonth(List<Record> data, int id)
        {
            var years = data
                .Where(x => x.ClientID == id)
                .GroupBy(x => x.Year)
                .Select(x => x
                    .Max(y => (
                        duration: y.Duration, 
                        rmonth: -y.Month, // этот странный хак нужен чтобы выбирать месяц с меньшим номером
                        year: x.Key)))
                .Select(x => (x.duration, month: -x.rmonth, x.year)) // тут месяц становится нормальным
                .OrderByDescending(x => x.year)
                .ToArray();
            if (years.Length == 0)
            {
                Console.WriteLine("Нет данных о клиенте");
                return;
            }
            foreach (var (duration, month, year) in years)
                Console.WriteLine($"Год: {year}, месяц: {month}, продолжительность: {duration}");
        }
    }
}