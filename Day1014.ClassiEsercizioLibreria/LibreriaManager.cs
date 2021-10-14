using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioLibreria
{
    public static class LibreriaManager // anche questa è static, non ha delle istanze. sono solo metodi
    {
        //tutti i metodi, le "logiche" per fare le operazioni, ce li creiamo a parte in questa nuova classe! così resta pulito


        public static List<Libro> libri = new List<Libro>();

        public static void AggiungiLibro()
        {
            Libro libro = new Libro();

            Console.WriteLine("Inserisci codice");
            libro.Codice = Console.ReadLine();
            Console.WriteLine("Inserisci titolo");
            libro.Titolo = Console.ReadLine();
            Console.WriteLine("Inserisci autore");
            libro.Autore = Console.ReadLine();
            Console.WriteLine("Inserisci genere");
            //TODO libro.Genere = Console.ReadLine();
            Console.WriteLine("Inserisci prezzo");
            libro.Prezzo = InserisciPrezzo();
            Console.WriteLine("Inserisci data di pubblicazione");
            libro.DataPubblicazione = InserisciDataPubblicazione();
        }

        private static DateTime InserisciDataPubblicazione()
        {
            bool dataCorretta = DateTime.TryParse(Console.ReadLine(), out DateTime data);
            while ((!dataCorretta) || data < DateTime.Today)
            {
                Console.WriteLine("Inserisci una data corretta");
                dataCorretta = DateTime.TryParse(Console.ReadLine(), out data);
            }
            return data;
        }

        private static double InserisciPrezzo()
        {
            bool prezzoCorretto = double.TryParse(Console.ReadLine(), out double prezzo);
            while ((!prezzoCorretto) || prezzo <= 0)
            {
                Console.WriteLine("Inserisci un valore corretto");
                prezzoCorretto = double.TryParse(Console.ReadLine(), out prezzo);
            }
            return prezzo;
        }

        public static void RimuoviLibro()  //lui mette automaticamente "internal", diciamo che per ora mettiamo "public"
        {
            throw new NotImplementedException();
        }

        public static void ModificaLibro()
        {
            throw new NotImplementedException();
        }

        public static void StampaTuttiLibri()
        {
            throw new NotImplementedException();
        }

        public static void FiltraPerGenere()
        {
            throw new NotImplementedException();
        }
    }
}
