using System;

namespace Day1013.RicorsioneFattoriale
{
    class Program
    {
        static void Main(string[] args)
        {
            // fattoriale di N: prodotto di N(N-1)(N-2)....


            Console.WriteLine(FattorialeIterativo(5));
            Console.WriteLine(FattorialeRicorsivo(5));
        }


        private static int FattorialeRicorsivo(int N)
        {

            int fattorialeN;

            if (N == 0 || N == 1)
            {
                fattorialeN = 1;
            }
            else
            {
                fattorialeN = FattorialeRicorsivo(N - 1) * N;
            }

            return fattorialeN;
        }

        private static int FattorialeIterativo (int N)
        {
            
            int prodotto = 1;

            for (int i= 1; i < N+1; i++)
            {
                prodotto = i * prodotto; //come dire prodotto *= i ?
            }

            return prodotto;
        }

    }
}
