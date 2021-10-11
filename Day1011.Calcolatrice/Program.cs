using System;

namespace Day1011.Calcolatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ciao! Benvenuto in Calcolatrice"); //anche questo è un metodo! "già fatto". la stringa data è l'input
            Console.WriteLine("Come ti chiami?");

            string nomeUtente;  // dichiarazione (nome e tipo della variabile)
                                // i nomi delle variabili per convenzioni iniziano con la minuscola
                                // se devo aggiungere una seconda parola la metto maiuscola (notazione "cammello")

            // così come è ora è solo dichiarata, non è ancora inizializzata

            nomeUtente = Console.ReadLine(); //metodo che prende in input dalla console

            Console.WriteLine($"Ciao {nomeUtente}");
            // Console.Write("Inserisci il primo numero intero:"); //Write vs WriteLine: il cursore non va a capo

            #region introduzione del tryparse

            // int primoNumero;
            // primoNumero = int.Parse(Console.ReadLine());    //metodo che presuppone la convertibilità dell'input


            // int.TryParse()       se scrivo questo e vado sul nome mi dice tutta la "firma" del metodo
            // suggerimento quindi su come scrivere il comando!
            // es. nei parametri dà la readline E out int nome, ovvero il numero che esce dalla conversione

            // int.TryParse(Console.ReadLine(), out int primoNumero); //posso fare anche così: il true/false è comunque reso, ma non lo memorizzo in variabile
            //non va comunque in eccezione; il programma va avanti, e primoNumero viene 
            //inizializzato col valore di default (0)

            #endregion

            #region alternative di ciclo per soddisfare il tryparse: inserimento di 1o e 2o numero

            /* bool esitoConversione = int.TryParse(Console.ReadLine(), out int primoNumero);        //posso fare così e memorizzarmi il booleano reso dalla conversione
                    
            while (!esitoConversione)
             {
                 Console.WriteLine("Inserimento non corretto! Inserisci un numero intero");
                 esitoConversione = int.TryParse(Console.ReadLine(), out primoNumero);       //questo deve stare dentro il while: devo dare l'opportunità al bool di cambiare!!
             }

             // in alternativa avremmo potuto usare un do while, che fa fare l'operazione ALMENO UNA VOLTA
             //sarebbe stato più sintetico

             */
            bool calcolaAncora = false;
            do
            {
                bool esitoConversione;
                int primoNumero;

                do
                {
                    Console.Write("Inserisci il primo numero intero:");

                } while (!int.TryParse(Console.ReadLine(), out primoNumero)); //così è mooolto più sintetica!
                                                                              // non ho bisogno di mettere il tryparse dentro il ciclo
                Console.WriteLine($"Il primo numero che hai inserito è: {primoNumero}");

                int secondoNumero;
                do
                {
                    Console.Write("Inserisci il secondo numero intero:");

                } while (!int.TryParse(Console.ReadLine(), out secondoNumero));
                Console.WriteLine($"Il secondo numero che hai inserito è: {secondoNumero}");

                #endregion

                StampaValori(primoNumero, secondoNumero);

                //devo proporre il menu di operazioni disponibili
                Console.WriteLine("\n------------------Menu------------------\n");
                Console.WriteLine("Scegli A per fare l'addizione");
                Console.WriteLine("Scegli B per fare la sottrazione");
                Console.WriteLine("Scegli C per fare la moltiplicazione");
                Console.WriteLine("Scegli D per fare la divisione");


                char operazioneUtente;
                do
                {
                    Console.WriteLine("\nFai la tua scelta");
                    operazioneUtente = Console.ReadKey().KeyChar;

                } while (operazioneUtente.ToString().ToUpper() != "A" && operazioneUtente.ToString().ToUpper() != "B" && operazioneUtente.ToString().ToUpper() != "C" && operazioneUtente.ToString().ToUpper() != "D");

                //ToUpper (stesso per ToLower) ha bisogno di una stringa, quindi c'è il passaggio intermedio .ToString().
                //sennò potevo prendere direttamente operazioneUtente come stringa invece che come char
                //se lascio operazioneUtente == 'A'  è un confronto CASE SENSITIVE, ovvero che se digito 'a' mi dà errore.

                switch (operazioneUtente.ToString().ToUpper())
                {
                    case "A":
                        int somma = primoNumero + secondoNumero;
                        Console.WriteLine($"\nLa somma è {somma}");
                        break;
                    case "B":
                        int differenza = primoNumero - secondoNumero;
                        Console.WriteLine($"\nLa differenza è {differenza}");
                        break;
                    case "C":
                        int prodotto = primoNumero * secondoNumero;
                        Console.WriteLine($"\nIl prodotto è {prodotto}");
                        break;
                    case "D":
                        if (secondoNumero == 0)
                        {
                            Console.WriteLine("\nImpossibile dividere per 0");
                        }
                        else
                        {
                            double quoziente = (double)primoNumero / secondoNumero;  //dobbiamo fare il cast, sennò comunque non dà un risultato double
                            Console.WriteLine($"\nIl quoziente è {quoziente}");
                        }
                        break;
                }
                Console.WriteLine("Vuoi inserire nuovi numeri per un nuovo calcolo?");
                Console.WriteLine("Inserisci si per continuare, qualsiasi altra cosa per uscire");
                if (Console.ReadLine() == "si")
                {
                    calcolaAncora = true;
                }

            } while (calcolaAncora);

            #region passaggio di valori BYREF
            //ModificaValoriByRef(ref primoNumero, ref secondoNumero);
            //StampaValori(primoNumero, secondoNumero);

            //faccio così se voglio partire da dei valori, modificarli in corsa e poi continuare a lavorare con essi
            //ma portandomi dietro le modifiche!!
            //contrapposto al passaggio per valore, dove io di fatto lavoro solo su una COPIA del valore
            #endregion

            #region passaggio valori OUT    
            //int somma = SommaEMoltiplica(primoNumero, secondoNumero, out int prodotto);

            //quand'è che si passano valori out? perché?
            //si fa quando ho bisogno che un metodo mi renda due cose  (magari anche di tipi diversi!)
            //perché tecnicamente un metodo rende UNA cosa sola, del tipo specificato

            //in questo caso, per esempio, avrei potuto in alternativa farmi rendere un ARRAY contenente somma e prodotto
            //invece che far rendere il prodotto "col trucco" dell'out. sarebbe stato possibile perché somma e prodotto sono entrambi int

            #endregion

        }


        /// <summary>
        /// restituisce in uscita la SOMMA dei due valori passati in input. In d (come out) mi restituisce il PRODOTTO 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static int SommaEMoltiplica(int a, int b, out int d)
        {
            d = a * b;

            return a+b;  //se non voglio fare int c, c= a+b. così è più stringato

        }

        
        private static void StampaValori(int a, int b) 
        {
            Console.WriteLine($"I due valori sono {a} e {b}");
        }


        private static void ModificaValoriByRef(ref int a, ref int b)
        {         //in questo caso passo per valore: lui si fa una copia del valore contenuto nelle variabili che gli passo, e lavora su quella copia
            a++;
            b++;
            Console.WriteLine($"I due valori sono {a} e {b}");

        }
    }
}
