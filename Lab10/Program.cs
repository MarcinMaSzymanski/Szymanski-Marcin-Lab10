using System;
using System.Threading;
//using UnityEngine;


namespace Lab10
{
    class Program
    {
        static void Main()
        {
            bool repeat = true;
            while (repeat)
            {
                Thread t = new Thread(sync);
                Console.WriteLine("Podaj numer cwiczenia");
                string cw = Console.ReadLine();
                if (cw == "1") Cw1();
                else if (cw == "2") Cw2();
                else if (cw == "3") ThreadTest.Cw3();
                else if (cw == "4") ThreadExample.Cw4_1();
                else if (cw == "5") ThreadExample1.Cw5();
                else if (cw == "6") ThreadExample2.Cw6();
                else if (cw == "7") Cw7.program();

                else
                {
                    Console.WriteLine("Podano nieprawidłową wartość!");
                    continue;
                }

                t.Start();
                t.Join();
                Console.WriteLine("Powtorzyc? (T/N)");
                string check = Console.ReadLine();
                if (check == "N") repeat = false;

            }

        }

        static void sync()
        {
        }

        static void Cw1()
        {
            Thread t = new Thread(Write1); //Uruchom inny wątek
            t.Start();
            // Główny wątek.
            for (int i = 0; i < 1000; i++) Console.Write("0");
        }
        //Inny wątek
        static void Write1()
        {
            for (int i = 0; i < 1000; i++) Console.Write("1");
        }

        static void Cw2()
        {
            new Thread(Run).Start(); // Uruchom Run w innym wątku
            Run(); // Uruchom Run w głownym wątku
        }
        static void Run()
        {
            // Deklaracja i użycie zmiennej lokalnej - 'cycles'
            for (int cycles = 0; cycles < 5; cycles++) Console.Write('x');
        }

        class ThreadTest
        {
            bool done;
            public static void Cw3()
            {
                ThreadTest tt = new ThreadTest();
                new Thread(tt.Run).Start();
                tt.Run();
            }
            // Zauważ, że Run jest teraz metodą instancji
            void Run()
            {
                if (!done) { done = true; Console.WriteLine("Done"); }
            }
        }

        class ThreadExample
        {
            static bool done; // Pole statyczne
            public static void Cw4()
            {
                new Thread(Run).Start();
                Run();
            }
            static void Run()
            {
                if (!done) { done = true; Console.WriteLine("Done"); }
            }

            public static void Cw4_1()
            {
                new Thread(Run_1).Start();
                Run_1();
            }

            static void Run_1()
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }

        class ThreadExample1
        {
            static bool done; // Pole statyczne

            static readonly object locker = new object();

            public static void Cw5()
            {
                new Thread(Run).Start();
                Run();
            }

            static void Run()
            {
                lock (locker)
                {
                    if (!done) { Console.WriteLine("Done"); done = true; }
                }
            }

        }

        class ThreadExample2
        {
            public static void Cw6()
            {
                Thread t = new Thread(Run);
                t.Start();
                t.Join();
                Console.WriteLine("Thread t has ended!");
            }
            static void Run()
            {
                for (int i = 0; i < 777; i++) Console.Write(":)");
            }
        }
    }
    
}
