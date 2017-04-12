using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SerialNumber.Components;

namespace ConsoleApplication
{
    class Program
    {
        public static void PrintList(List<int> lst)
        {
            foreach (var i in lst)
            {
                Console.Write(i+ " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var range = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var act = new List<int>();
            int startNumber = 1;
            SerialNumberBase.SetStartNumber(startNumber);

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                var el = SerialNumberBase.GetNumber();
                threads[i] = new Thread(() => act.Add(el));
                threads[i].Name = string.Format("Работает поток: #{0}", i);
            }

            foreach (Thread t in threads)
            { t.Start(); }

            PrintList(range);
            PrintList(act);
            Console.ReadKey();
        }
    }
}
