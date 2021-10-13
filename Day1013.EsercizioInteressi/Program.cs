using System;

namespace Day1013.EsercizioInteressi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Scrivere una funzione che dato un importo di denaro iniziale,
            // un interesse annuo e un numero di anni permette di calcolare
            // l’importo di denaro accresciuto degli interessi dopo il numero di anni passati

            // Esempio
            // Voglio vincolare 10000 euro per 3 anni con un interesse del 3%

            // Dopo 1 anno : 10000 + (10000 * 3 / 100) = 10000 + 300 = 10300
            // Dopo 2 anni : 10300 + (10300 * 3 / 100) = 10300 + 309 = 10609
            // Dopo 3 anni : 10609 + (10609 * 3 / 100) = 10609 + 318,27 = 10927,27


            Console.WriteLine(CalcolaImportoDopoNAnniRicors(10000, 3, 3));
            Console.WriteLine(CalcolaImportoDopoNAnniIterat(10000, 3, 3));
        }


        private static double CalcolaImportoDopoNAnniRicors(double importoIniziale, int n, double interesse)
        {
            double importoFinale;
            if (n == 1)
            {
                importoFinale = importoIniziale * (interesse / 100) + importoIniziale;
            }
            else
            {
                importoFinale = CalcolaImportoDopoNAnniRicors(importoIniziale, n-1, interesse) + CalcolaImportoDopoNAnniRicors(importoIniziale, n-1, interesse)*(interesse/100);
            }

            return importoFinale;
        }

        private static double CalcolaImportoDopoNAnniIterat(double importoIniziale, int n, double interesse)
        {
            double importoFinale = importoIniziale;

            for (int i = 1; i <= n; i++)
            {
                importoFinale = importoFinale + (importoFinale* (interesse / 100));
            }

            return importoFinale;
        }
    }
}
