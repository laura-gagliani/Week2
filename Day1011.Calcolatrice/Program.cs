using System;

namespace Day1011.Calcolatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //anche questo è un metodo! "già fatto". la stringa data è l'input
            Console.WriteLine("Come ti chiami?");

            string nomeUtente;  // dichiarazione (nome e tipo della variabile)
                                // i nomi delle variabili per convenzioni iniziano con la minuscola
                                // se devo aggiungere una seconda parola la metto maiuscola (notazione "cammello")

            // così come è ora è solo dichiarata, non è ancora inizializzata

            nomeUtente = Console.ReadLine(); //metodo che prende in input dalla console

            Console.WriteLine($"Ciao {nomeUtente}");
            Console.Write("Inserisci il primo numero intero:"); //Write vs WriteLine: il cursore non va a capo

            // int primoNumero;
            // primoNumero = int.Parse(Console.ReadLine());    //metodo che presuppone la convertibilità dell'input


            // int.TryParse()       se scrivo questo e vado sul nome mi dice tutta la "firma" del metodo
                                // suggerimento quindi su come scrivere il comando!
                                // es. nei parametri dà la readline E out int nome, ovvero il numero che esce dalla conversione

           // int.TryParse(Console.ReadLine(), out int primoNumero); //posso fare anche così: il true/false è comunque reso, ma non lo memorizzo in variabile
                                                                   //non va comunque in eccezione; il programma va avanti, e primoNumero viene 
                                                                   //inizializzato col valore di default (0)

            bool esitoConversione = int.TryParse(Console.ReadLine(), out int primoNumero);        //posso fare così e memorizzarmi il booleano reso dalla conversione

            while (!esitoConversione)
            {
                Console.WriteLine("Inserimento non corretto! Inserisci un numero intero");
                esitoConversione = int.TryParse(Console.ReadLine(), out primoNumero);       //questo deve stare dentro il while: devo dare l'opportunità al bool di cambiare!!
            }



            Console.WriteLine($"Il primo numero che hai inserito è: {primoNumero}"); 




        }
    }
}
