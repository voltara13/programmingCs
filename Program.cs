/*
EX1 - первое задание
EX2 - второе по четвертое задание
*/
#define EX2

using System;
using System.Collections.Generic;
using System.Linq;

namespace programmingCs
{
    class Program
    {
        static void Main()
        {
#if EX1
            string[] month =
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };
            Console.Write("Введите N: ");
            var n = Convert.ToInt32(Console.ReadLine());
            var monthSelectN = month.Where(i => i.Length == n);
            Console.WriteLine("\nРазмера N:");
            foreach (var elm in monthSelectN)
                Console.WriteLine(elm);
            var monthSelectWS = month.Where(i => 
                i.StartsWith("Jan") ||
                i.StartsWith("Feb") || 
                i.StartsWith("Jun") || 
                i.StartsWith("Jul") ||
                i.StartsWith("Aug") || 
                i.StartsWith("Dec"));
            Console.WriteLine("\nТолько зимние и летние:");
            foreach (var elm in monthSelectWS)
                Console.WriteLine(elm);
            var monthSelectSort = month.OrderBy(i => i);
            Console.WriteLine("\nВ алфавитном порядке:");
            foreach (var elm in monthSelectSort)
                Console.WriteLine(elm);
            var monthSelectCond = month.Where(i => i.Contains("u") && i.Length >= 4);
            Console.WriteLine("\nСодержащие 'u' и длиной не меньше 4:");
            foreach (var elm in monthSelectCond)
                Console.WriteLine(elm);
#endif
#if EX2
            List<Airline> airlines = new List<Airline>();

            airlines.Add(new Airline(
                "Санкт-Петербург", 
                "A105B3", 
                "16/12/2020 12:15:16"));
            airlines.Add(new Airline(
                "Санкт-Петербург",
                "A10683",
                "18/12/2020 16:05:09"));
            airlines.Add(new Airline(
                "Москва",
                "A130BG",
                "21/12/2020 17:09:11"));
            airlines.Add(new Airline(
                "Новосибирск",
                "A148KL",
                "21/12/2020 10:12:48"));

            Console.Write("Введите пункт назначения: ");
            var destinationSearch = Console.ReadLine();
            var airlinesDestCond = airlines
                .Where(i => i.Destination.ToLower() == destinationSearch.ToLower());
            if (airlinesDestCond.Count() != 0)
            {
                Console.WriteLine($"Рейсы, летящие в город {destinationSearch}");
                foreach (var elm in airlinesDestCond)
                    Console.WriteLine(elm);
            }
            else
                Console.WriteLine("Совпадения не найдены");

            Console.Write("\nВведите день недели: ");
            var dayWeek = Console.ReadLine();
            var airlinesCount = airlines.Count(i => i.DayWeek.ToLower() == dayWeek.ToLower());
            Console.WriteLine($"Количество рейсов вылетающих в {dayWeek}: {airlinesCount}");

            var airlinesBeforeCond = airlines
                .Where(i => i.DayWeek == "понедельник")
                .OrderBy(i => i.DepartureTime)
                .First();
            Console.WriteLine($"\nРейс, который вылетает в понедельник раньше всех:\n{airlinesBeforeCond}");

            var airlinesLaterCond = airlines
                .Where(i => i.DayWeek == "среда" || i.DayWeek == "пятница")
                .OrderByDescending(i => i.DepartureTime)
                .First();
            Console.WriteLine($"\nРейс, который вылетает в среду или пятницу позже всех:\n{airlinesLaterCond}");

            var airlinesSortByTime = airlines.OrderBy(i => i.DepartureTime);
            Console.WriteLine("\nОтсортированный по времени вылета список:");
            foreach (var elm in airlinesSortByTime)
                Console.WriteLine(elm);
#endif
        }
    }
}