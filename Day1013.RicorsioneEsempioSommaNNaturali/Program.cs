using System;

namespace Day1013.RicorsioneEsempioSommaNNaturali
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcolare la somma dei primi N numeri naturali");

            int N = 20;

            int sommaFor = SommaIterazioneFor(N);

            int sommaWhile = SommaIterazioneWhile(N);       //oppure con un ciclo while, stessa cosa

            //e se invece lo voglio fare con una funzione RICORSIVA?

        }

        private static int SommaIterazioneWhile(int n)
        {
            int i = 0;
            int somma = 0;

            while (i <= n)
            {
                somma += i;
                i++;
            }

            return somma;
        }

        private static int SommaIterazioneFor(int n)
        {
            int somma = 0;
            for (int i = 0; i <= n; i++)
            {
                somma = somma + i; //abbreviabile come somma += i;
            }

            return somma;
        }


        private static int SommaRicorsione(int n)
        {
            int somma = 0;
            if (n == 1)
            {
                return somma = 1;
            }
            else
            {
                return somma = SommaRicorsione(n - 1) + n;

            }
        }
    }
}
