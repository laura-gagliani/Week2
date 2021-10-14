using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioLibreria
{
    public static class Menu        //scriviamo anche "static" qua
                                    //questa contiene un metodo di fatto
                                    //menu non è un oggetto, non creo istanze menu1, menu2, menu3 come per la classe libri
                                    //per questo è static
                                    //comunque posso accedere alla classe dal main del program
    {
        public static void Start()
        {
            bool nuovaOperazione = true;
            Console.WriteLine("------------Benvenuto!------------\n");
            do
            {
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
                        //TODO aggiungi libro
                        break;
                    case 2:
                        //TODO togli libro
                        break;
                    case 3:
                        //TODO modifica libro
                        break;
                    case 4:
                        //TODO stampa tutti libri
                        break;
                    case 5:
                        //TODO filtra per genere
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
