using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioConto
{
    class Menu
    {
        internal static void Start()
        {
            Console.WriteLine("----------------Menu gestione conti bancari----------------");
            bool nuovaOperazione = true;
            while (nuovaOperazione)
            {
                Console.WriteLine("\nComandi:");
                Console.WriteLine("Premi 1 per aprire un conto");
                Console.WriteLine("Premi 2 per chiudere un conto");
                Console.WriteLine("Premi 3 per riepilogare i dati relativi a un conto");
                Console.WriteLine("Premi 0 per uscire");

                int selezioneMenu = ContiManager.GetMenuInputNumber(0, 3);

                switch (selezioneMenu)
                {
                    case 0:
                        nuovaOperazione = false;
                        break;
                    case 1:
                        ContiManager.ApriConto();
                        break;
                    case 2:
                        ContiManager.ChiudiConto();
                        break;
                    case 3:
                        ContiManager.RiepilogaDatiConto();
                        break;

                }

            }


        }
    }
}
