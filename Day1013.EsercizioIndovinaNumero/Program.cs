using System;
using System.IO;

namespace Day1013.EsercizioIndovinaNumero
{
    class Program
    {
        static void Main(string[] args)
        {
            //        Esercizio: Indovina Numero.
            //Il gioco consiste nell’indovinare un numero tra 1 e 100, generato in modo casuale.



            //L’utente accede e visualizza un messaggio di benvenuto.
            //Gli viene chiesto di inserire il suo nome, quindi, una volta inserito,
            //compare un messaggio del tipo “Ciao NOME!” ed un menu con delle scelte/ opzioni.
            //In particolare potrà scegliere se iniziare a giocare una partita o uscire dal programma.



            //Se l’utente decide di uscire, verrà visualizzato un messaggio di arrivederci.



            //Se invece decide di giocare dovrà essere generato un numero casuale
            //che ovviamente NON dovrà essere mostrato a video.
            //(Opzionale: il numero può essere salvato in un file “NumeroDaIndovinare.txt”).



            //Dopo la generazione e memorizzazione del numero casuale,
            //si dovrà chiedere all’utente di provare ad indovinare il numero
            //specificando a video(e quindi controllando in fase di inserimento)
            //che si tratta di un numero compreso tra 1 e 100.
            //(Opzionale: Se l’utente inserisce “0” interrompe la partita e
            //gli verrà mostrato un messaggio di “Partita interrotta” quindi
            //svelato il numero che doveva indovinare.Ritornerà quindi al menu iniziale.)

            //Bisognerà tener traccia dei tentativi che fa,
            //mostrando il numero dei tentativi che sono stati fatti.

            //--------------------------------------------------------------------
            //Esempio:
            //            Finora hai effettuato 0 tentativi.
            //Inserisci il tuo 1° tentativo(0 per interrompere la partita):
            //--------------------------------------------------------------------



            //L’utente dovrà provare quindi ad indovinare il numero.
            //Ogni volta che l’utente prova ad inserire un numero, cioè inserisce un tentativo,
            //bisognerà quindi verificare se il numero inserito corrisponde al numero segreto.
            //Se l’utente NON indovina il numero, gli verrà mostrato un suggerimento del tipo
            //“Prova con un numero più alto” o “Prova con un numero più basso”
            //in base al confronto tra il numero che l’utente ha inserito e il numero segreto.
            //Quindi l’utente farà un altro tentativo e così via finché indovina il numero!



            //---------------------------------------------------------------------------------------
            //Esempio(Il numero da indovinare è 20 e l'utente inserisce come secondo tentativo 15):



            //Suggerimento: Inserisci un numero più alto.
            //Finora hai effettuato 2 tentativi.
            //Inserisci il tuo 3° tentativo(0 per interrompere la partita):
            //---------------------------------------------------------------------------------------

            //Se / quando l’utente indovina il numero, verrà visualizzato il messaggio:
            //“Complimenti hai vinto! Ti sono bastati X tentativi! Bravo!”.
            //E verrà rimandato al menu iniziale.



            string nomeUtente = SalutaGiocatore();
            
            bool playAgain = false;


            do
            {
                string path = GeneraESalvaRndNum();
                Console.WriteLine("\n---------------------------------------------------\n");
                Console.WriteLine("\nIl computer ha estratto un numero tra 1 e 100");
                Console.WriteLine("Prova a indovinarlo!");
                Console.WriteLine("\n(In qualsiasi momento potrai premere 0 per uscire dal gioco)\n");


                int guess = OttieniGuessUtente();
                if (guess == 0)
                {
                    return;
                }

                int tentativi = 0;
                int rndNum;

                using (StreamReader sr1 = new StreamReader(path))
                {
                    rndNum = int.Parse(sr1.ReadLine());
                }


                while (guess != rndNum)
                {
                    if (guess > rndNum)
                    {
                        Console.WriteLine("\nSuggerimento: prova con un numero più basso...");

                    }
                    else if (guess < rndNum)
                    {
                        Console.WriteLine("\nSuggerimento: prova con un numero più alto...");

                    }

                    Console.WriteLine($"Finora hai effettuato {tentativi + 1} tentativi");
                    Console.WriteLine("\nProva con un nuovo numero:");
                    tentativi++;
                    guess = OttieniGuessUtente();
                    if (guess == 0)
                    {
                        return;
                    }
                }

                if (guess == rndNum)
                {
                    Console.WriteLine($"\nComplimenti! Hai indovinato al {tentativi + 1}° tentativo!");
                }

                Console.WriteLine("Vuoi giocare di nuovo? se sì premi x, altrimenti premi qualsiasi altro tasto per chiudere");
                if (Console.ReadKey().KeyChar == 'x')
                {
                    playAgain = true;
                }

            } while (playAgain);


        }

        private static string SalutaGiocatore()
        {
            Console.WriteLine("Benvenuto! Come ti chiami?");
            string nomeUtente = Console.ReadLine();
            Console.WriteLine($"Ciao {nomeUtente}! Giochiamo!");
            return nomeUtente;
        }

        private static string GeneraESalvaRndNum()
        {
            Random rndGen = new Random();
            int rndNum = rndGen.Next(1, 101);

            string path = @"F:\Laura\Documenti\Avanade\Academy\Week2\Day1013.EsercizioIndovinaNumero\NumeroRnd.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(rndNum);   //in questo modo sovrascrive (c'è sempre solo un numero random nel documento di testo
            sw.Close();

            return path;

        }

        private static int OttieniGuessUtente()
        {
            
            bool inserimentoCorretto = int.TryParse(Console.ReadLine(), out int guess);
            
            while ((!inserimentoCorretto) || guess > 100 || guess < 0)
            {
                Console.WriteLine("Inserimento scorretto. Prova ancora");
                inserimentoCorretto = int.TryParse(Console.ReadLine(), out guess);
            }
            return guess;
        }


    }
}
