using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioLibreria
{
    public static class Menu        //scriviamo anche "static" qua
                                    //questa contiene un metodo, di fatto
                                    //menu non è un oggetto, non creo istanze menu1, menu2, menu3 come per la classe libri
                                    //per questo è static
                                    //comunque posso accedere (essendo public) alla classe dal main del program
    {
        public static void Start()
        {
            bool nuovaOperazione = true;
            Console.WriteLine("*** Benvenuto! ***");
            LibreriaManager.AggiungiDatiDiProva();
            do
            {
                Console.WriteLine("\n------------------------------------\n");
                Console.WriteLine("Premi 1 per aggiungere un libro");
                Console.WriteLine("Premi 2 per eliminare un libro");
                Console.WriteLine("Premi 3 per modificare un libro");
                Console.WriteLine("Premi 4 per stampare tutti i libri");
                Console.WriteLine("Premi 5 per estrarre i libri per genere");
                Console.WriteLine("Premi 0 per uscire");

                int scelta;
                bool sceltaCorretta = int.TryParse(Console.ReadLine(), out scelta);

                while ((!sceltaCorretta) || scelta < 0 || scelta > 5)
                {
                    Console.WriteLine("Inserimento errato. Riprova");
                    sceltaCorretta = int.TryParse(Console.ReadLine(), out scelta);
                }

                switch (scelta)
                {
                    case 1:
                        LibreriaManager.AggiungiLibro();
                        break;
                    case 2:
                        LibreriaManager.RimuoviLibro();
                        break;
                    case 3:
                        LibreriaManager.ModificaLibro();
                        break;
                    case 4:
                        LibreriaManager.StampaTuttiLibri();
                        break;
                    case 5:
                        LibreriaManager.FiltraPerGenere();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci!");
                        nuovaOperazione = false;
                        break;
                }

            } while (nuovaOperazione);


        }
    }
}
