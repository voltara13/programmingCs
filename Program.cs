/*
EX1 - первое задание
EX2 - второе по четвертое задание
*/
#define EX1

using System;
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
            var n = Convert.ToInt32(Console.ReadLine());
            var monthSelect = from i in month
                where i.Length == n
                select i;
            foreach (var elm in monthSelect)
                Console.WriteLine(elm);

#endif
#if EX2
#endif
#if EX3
#endif
#if EX4
#endif
        }
    }

}