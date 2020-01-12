using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab10
{
    class Cw7
    {
        static int suma = 0;
        static int count = 1;
        static int nr_watku = 1;
        static bool done = false;

        static readonly object m_SyncObject = new object();

        public static void program()
        {
            for(int x = 0; x<5; x++)
            {
                new Thread(Run).Start();
            }
        }

        static private int[][] randomMatrix()
        {
            int[][] matrix = new int[3][];

            Random rand = new Random();

            for (int i=0; i<matrix.Length; i++)
            {
                int[] a = new int[3];
                for (int j=0; j<a.Length; j++)
                {
                    a[j]= rand.Next(1, 20);
                }
                matrix[i] = a;
            }

            return matrix;
        }

        static void Run()
        {
           
            int[][] matrix = randomMatrix();

            lock(m_SyncObject)
            {
                string nazwa = nr_watku.ToString();
                nr_watku++;

                Console.WriteLine("Macierz w wątku: " + nazwa);

                int s = 0;

                foreach (var el in matrix)
                {
                    string text = "";
                    foreach (var e in el)
                    {
                        text = text + e.ToString() + " ";
                        s = s + e;
                    }
                    Console.WriteLine(text);
                }

                Console.WriteLine("Suma elementów macierzy w wątku: " + nazwa + " wynosi: " + s);

                suma = suma + s;

                if (count == 5)
                {
                    Console.WriteLine("Suma wszystkich elementów macierzy wynosi: " + suma);
                    count = 0;
                    suma = 0;
                    nr_watku = 0;
                }
                else count++;
            }


        }
    }
}
