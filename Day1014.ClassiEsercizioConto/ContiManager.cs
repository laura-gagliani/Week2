using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioConto
{
    public static class ContiManager
    {
        public static List<Conto> listaConti = new List<Conto>();

        public static int GetMenuInputNumber(int limiteInferiore, int limiteSuperiore)
        {
            bool selezioneCorretta = int.TryParse(Console.ReadLine(), out int selezioneMenu);
            while ((!selezioneCorretta) || selezioneMenu < limiteInferiore || selezioneMenu > limiteSuperiore)
            {
                Console.WriteLine("Errore. Seleziona di nuovo");
                selezioneCorretta = int.TryParse(Console.ReadLine(), out selezioneMenu);
            }

            return selezioneMenu;
        }

        internal static void ApriConto()
        {
            Conto conto = new Conto();
            InserisciProprietàConto(conto);
            listaConti.Add(conto);
        }

        private static void InserisciProprietàConto(Conto conto)
        {
            Console.WriteLine("Inserisci nome intestatario");
            conto.NomeIntestatario = Console.ReadLine();
            Console.WriteLine("Inserisci cognome intestatario");
            conto.CognomeIntestatario = Console.ReadLine();
            Console.WriteLine("Inserisci coordinate univoche");
            conto.CoordinateBancarie = InserisciCoordinateBancarie(); 
            Console.WriteLine("Inserisci tipo di conto");
            conto.TipoDiConto = InserisciTipoDiConto(); //TODO
            Console.WriteLine("Inserisci saldo");
            conto.SaldoConto = InserisciSaldo(); //TODO
            
        }

        private static double InserisciSaldo()
        {
            throw new NotImplementedException();
        }

        private static int InserisciTipoDiConto()
        {
            throw new NotImplementedException();
        }

        private static string InserisciCoordinateBancarie()
        {
            string coordinate = Console.ReadLine();
            do
            {
                Console.WriteLine("Errore! Lunghezza incorretta del codice alfanumerico");
                coordinate = Console.ReadLine();
            }
            while (coordinate.Length != 16);
            return coordinate;
        }

        internal static void ChiudiConto()
        {
            //TODO inserimento coord. univoche come stringa
            string coordinate = null;
            listaConti.Remove(CercaContoDaCoordinate(coordinate)); //TODO
        }

        private static Conto CercaContoDaCoordinate(string coordinate)
        {
            throw new NotImplementedException();
        }

        internal static void RiepilogaDatiConto()
        {
            throw new NotImplementedException();
        }
    }
}
