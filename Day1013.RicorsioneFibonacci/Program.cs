using System;

namespace Day1013.RicorsioneFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 15;

            int[] fibonacci = FibonacciIterazione(n);

            for (int i = 0; i < fibonacci.Length; i++)
            {
                Console.Write($"{fibonacci[i]} ");
            }

            Console.WriteLine("");
            int[] fibonacciR = FibonacciRicorsiva(n);

            for (int i = 0; i < fibonacciR.Length; i++)
            {
                Console.Write($"{fibonacciR[i]} ");
            }

        }

        private static int[] FibonacciIterazione(int N)
        {

            int[] array = new int[N];

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    array[i] = 1;
                }
                else
                {
                    array[i] = array[i - 1] + array[i - 2];
                }
            }

            return array;
        }

        private static int[] FibonacciRicorsiva(int N)
        {
            int[] array = new int[N];

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    array[i] = 1;
                }

                else
                {
                    array[i] = PopolaNesimoFibonacci(i + 1);
                }
            }
            return array;
        }

        private static int PopolaNesimoFibonacci(int posizione)
        {
            int valore;

            if (posizione == 1 || posizione == 2)
            {
                valore = 1;
            }
            else
            {
                valore = PopolaNesimoFibonacci(posizione - 1) + PopolaNesimoFibonacci(posizione - 2);
            }

            return valore;
        }
    }
}
