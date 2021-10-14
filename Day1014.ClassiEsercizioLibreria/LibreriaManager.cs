using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioLibreria
{
    public static class LibreriaManager
    {


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
            Console.WriteLine($"Premi {(int)Genere.Classici} per il genere {Genere.Classici}");
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
            Console.WriteLine("\nI libri presenti in libreria sono:");
            StampaTuttiLibri();
            Console.WriteLine("\nDigita il codice del libro che vuoi modificare");
            string codice = Console.ReadLine();

            Libro libroDaModificare = CercaLibroPerCodice(codice, libri);
            if (libroDaModificare == null)
            {
                Console.WriteLine("Attenzione! Non è stato trovato nessun libro con questo codice");
            }
            else
            {
                bool modificheRipetute = true;
                while (modificheRipetute)
                {
                    Console.WriteLine("Premi 1 per modificare il titolo");
                    Console.WriteLine("Premi 2 per modificare l'autore");
                    Console.WriteLine("Premi 3 per modificare il genere");
                    Console.WriteLine("Premi 4 per modificare il prezzo");
                    Console.WriteLine("Premi 5 per modificare la data di pubblicazione");
                    Console.WriteLine("Premi 0 per uscire dal menu modifiche");

                    bool sceltaCorretta = int.TryParse(Console.ReadLine(), out int scelta);

                    while ((!sceltaCorretta) || scelta < 0 || scelta > 5)
                    {
                        Console.WriteLine("Errore. Seleziona un campo corretto");
                        sceltaCorretta = int.TryParse(Console.ReadLine(), out scelta);
                    }

                    switch (scelta)
                    {
                        case 1:
                            Console.WriteLine("Inserisci nuovo titolo");
                            libroDaModificare.Titolo = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Inserisci nuovo autore");
                            libroDaModificare.Autore = Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Inserisci nuovo genere");
                            libroDaModificare.Genere = InserisciGenere();
                            break;
                        case 4:
                            Console.WriteLine("Inserisci nuovo prezzo");
                            libroDaModificare.Prezzo = InserisciPrezzo();
                            break;
                        case 5:
                            Console.WriteLine("Inserisci nuova data di pubblicazione");
                            libroDaModificare.DataPubblicazione = InserisciDataPubblicazione();
                            break;
                        case 0:
                            modificheRipetute = false;
                            break;
                    }
                }

            }

        }

        public static void StampaLibriDiUnaLista(List<Libro> lista)
        {
            if (libri.Count == 0)
            {
                Console.WriteLine("Lista vuota. Nessun libro trovato");
            }
            else
            {
                Console.WriteLine("Codice\t\tTitolo\t\t\tAutore\t\tGenere\t\tPrezzo\t\tData di pubblicazione");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                foreach (var item in lista)
                {
                    Console.Write($"{item.Codice}\t\t{item.Titolo}\t{item.Autore}\t\t{item.Genere}\t\t{item.Prezzo}\t\t{item.DataPubblicazione.ToShortDateString()}\n");
                }
            }

        }

        public static void StampaTuttiLibri()
        {
            StampaLibriDiUnaLista(libri);
        }

        public static void FiltraPerGenere(List<Libro> lista)
        {
            List<Libro> libriFiltrati = new List<Libro>();
            Genere genereRichiesto = InserisciGenere();
            foreach (var item in lista)
            {
                if (genereRichiesto == item.Genere)
                {
                    libriFiltrati.Add(item);
                }
            }

            StampaLibriDiUnaLista(libriFiltrati);
        }


        public static void AggiungiDatiDiProva()
        {
            Libro libro1 = new Libro() { Codice = "001", Titolo = "I promessi sposi", Autore = "Manzoni", Genere = (Genere)1, Prezzo = 12.66, DataPubblicazione = new DateTime(1830, 02, 04) };
            libri.Add(libro1);

            Libro libro2 = new Libro() { Codice = "002", Titolo = "Pinocchio       ", Autore = "Collodi", Genere = (Genere)0, Prezzo = 8.50, DataPubblicazione = new DateTime(1880, 02, 04) };
            libri.Add(libro2);

            Libro libro3 = new Libro() { Codice = "003", Titolo = "il nome della rosa", Autore = "U.Eco", Genere = (Genere)1, Prezzo = 17.90, DataPubblicazione = new DateTime(1985, 02, 04) };
            libri.Add(libro3);

        }
    }
}
