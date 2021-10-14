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
            libro.Genere = InserisciGenere();
            Console.WriteLine("Inserisci prezzo");
            libro.Prezzo = InserisciPrezzo();
            Console.WriteLine("Inserisci data di pubblicazione");
            libro.DataPubblicazione = InserisciDataPubblicazione();

            libri.Add(libro);
            Console.WriteLine("Libro aggiunto correttamente");

        }

        private static Genere InserisciGenere()
        {
            Console.WriteLine($"Premi {(int)Genere.Narrativa} per il genere {Genere.Narrativa}");
            Console.WriteLine($"Premi {(int)Genere.Storico} per il genere {Genere.Storico}");
            Console.WriteLine($"Premi {(int)Genere.Fantasy} per il genere {Genere.Fantasy}");
            Console.WriteLine($"Premi {(int)Genere.Saggistica} per il genere {Genere.Saggistica}");
            Console.WriteLine($"Premi {(int)Genere.Storico} per il genere {Genere.Storico}");
            bool genereCorretto = int.TryParse(Console.ReadLine(), out int numeroGenere);

            while ((!genereCorretto) || numeroGenere < 0 || numeroGenere > 4)
            {
                Console.WriteLine("Errore. Seleziona un genere corretto");
                genereCorretto = int.TryParse(Console.ReadLine(), out numeroGenere);
            }
            return (Genere)numeroGenere;
        }

        private static DateTime InserisciDataPubblicazione()
        {
            bool dataCorretta = DateTime.TryParse(Console.ReadLine(), out DateTime data);
            while ((!dataCorretta) || data > DateTime.Today)
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

        /// <summary>
        /// Dati in input il codice cercato e la lista dove cercare, cerca il libro corrispondente e rende l'oggetto libro
        /// </summary>
        /// <param name="codice"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static Libro CercaLibroPerCodice(string codice, List<Libro> lista)
        {
            foreach (var item in lista)
            {
                if (item.Codice == codice)
                {
                    return item; // quando fa return esce dal metodo, non va a fare return null dopo
                }
            }
            return null;
        }

        public static void RimuoviLibro()  
        {
            Console.WriteLine("\nI libri presenti in libreria sono:");
            StampaTuttiLibri();
            Console.WriteLine("\nDigita il codice del libro che vuoi rimuovere");
            string codice = Console.ReadLine();

            Libro libroDaRimuovere = CercaLibroPerCodice(codice, libri);
            if (libroDaRimuovere == null)
            {
                Console.WriteLine("Attenzione! Non è stato trovato nessun libro con questo codice");
            }
            else
            {
                libri.Remove(libroDaRimuovere);
                Console.WriteLine("Il libro richiesto è stato eliminato dalla libreria");
            }
        }

        public static void ModificaLibro()
        {
            throw new NotImplementedException();
        }

        public static void StampaLibriDiUnaLista(List<Libro> lista)
        {
            if (libri.Count == 0)
            {
                Console.WriteLine("Lista vuota. Nessun libro trovato");
            }
            else
            {
                Console.WriteLine("Codice\t\tTitolo\t\t\tAutore\t\t\tGenere\t\tPrezzo\t\tData di pubblicazione");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                foreach (var item in lista)
                {
                    Console.Write($"{item.Codice}\t\t{item.Titolo}\t{item.Autore}\t{item.Genere}\t\t{item.Prezzo}\t\t{item.DataPubblicazione.ToShortDateString()}\n");
                }
            }

        }

        public static void StampaTuttiLibri()
        {
            StampaLibriDiUnaLista(libri);
        }

        public static void FiltraPerGenere()
        {
            throw new NotImplementedException();
        }


        public static void AggiungiDatiDiProva()
        {
            Libro libro1 = new Libro() {Codice = "001", Titolo = "I promessi sposi", DataPubblicazione = new DateTime(1830, 02, 04) };
            libri.Add(libro1);

            Libro libro2 = new Libro() { Codice = "002", Titolo = "Pinocchio" };
            libri.Add(libro2);
        }
    }
}
