using System;

namespace Day1011.EsercizioBolletta
{
    class Program
    {
        static void Main(string[] args)
        {
            //Realizzare un’applicazione console che consenta di eseguire il calcolo della bolletta della luce.
            //Si richiede di sviluppare un menù attraverso cui l’utente può scegliere di:

            //inserire i propri dati(nome, cognome e kwH consumati);
            //richiedere il calcolo del costo della bolletta che è costituito da una quota fissa di 40€ più il prodotto tra i kwH e 10.
            //stampare a video i valori della bolletta, inclusi nome, cognome e costo pagato.
            //Ciascuna delle operazioni descritte sopra dovrà essere implementata attraverso una opportuna routine.

            Console.WriteLine("*****Benvenuto*****");

            Console.WriteLine("Menu:");                                 //questa parte del menu può essere messa come metodo
            Console.WriteLine("(1) Inserimento dati");                  //es. private static void Menu()
            Console.WriteLine("(2) Calcolo costo della bolletta");      //che fa solo stampe, senza rendere niente
            Console.WriteLine("(3) Riepilogo dati");
            
            Console.WriteLine("\nDigita il numero corrispondente alla voce desiderata");  //anche qui si può fare un metodo
            bool choice = int.TryParse(Console.ReadLine(), out int menuChoice);           //es. private static int Scegli()
            while ((!choice) && menuChoice < 1 && menuChoice > 3)                         //che rende il numero di selezione dal menu
            {
                Console.WriteLine("\nErrore nell'inserimento. Riprova");
                choice = int.TryParse(Console.ReadLine(), out menuChoice);

            }
            bool login = false;
            int consumo = 0;
            int costo = 0;
            string nomeUtente = null;
            string cognomeUtente = null;

            //in questo caso un metodo con out sarebbe stato "poco sensato", perché comunque la presenza
            //dello switch case rende obbligatorio il dichiarare le variabili all'inizio. 
            //cambiato con by ref (la variabile è dichiarata e inizializzata, il metodo ci va a sovrascrivere)

            switch (menuChoice)
            {
                case 1:
                    login = LogIn(ref consumo, ref nomeUtente, ref cognomeUtente);
                    break;
                case 2:
                    if (!login) {
                        Console.WriteLine("Attenzione! Dati non inseriti");
                        login = LogIn(ref consumo, ref nomeUtente, ref cognomeUtente);
                    }
                    costo = CalcolaBolletta(consumo);
                    Console.WriteLine($"La tua bolletta ha un costo di {costo} euro");
                    break;
                case 3:
                    if (!login)
                    {
                        Console.WriteLine("Attenzione! Dati non inseriti");
                        login = LogIn(ref consumo, ref nomeUtente, ref cognomeUtente);
                    }
                    costo = CalcolaBolletta(consumo);
                    Riepiloga(consumo, costo, nomeUtente, cognomeUtente);
                    break;                                                      //se metto es. premi 0 per uscire posso mettere un "case 0"
                                                                                //(nell'ottica di avere un ciclo che ripropone il menu)
                                                                                //nel quale posso usare return, oppure mettere falso ad un booleano
                                                                                //in modo da rompere il ciclo!
            }
            
        }

        private static bool LogIn(ref int consumo, ref string nomeUtente, ref string cognomeUtente)
        {
            bool login;
            Console.WriteLine("*****Log In*****");
            Console.WriteLine("\nNome:");
            nomeUtente = Console.ReadLine();
            Console.WriteLine("\nCognome:");
            cognomeUtente = Console.ReadLine();
            Console.WriteLine("\nkwH consumati:");
            bool consumoCorretto = int.TryParse(Console.ReadLine(), out  consumo);
            while (!consumoCorretto)                                                //altra condizione sensata sarebbe consumo >= 0 !!
            {
                Console.WriteLine("\nErrore. Reinserire il valore:");
                consumoCorretto = int.TryParse(Console.ReadLine(), out consumo);
            }

            Console.WriteLine("\nDati inseriti con successo");

            return login = true;
        }

        private static int CalcolaBolletta(int consumo)
        {
            int costo = 40 + (consumo * 10);                    //qua poteva essere passato il 40 come int quotaFissa, per esempio
            return costo;
        } 

        private static void Riepiloga(int consumo, int costo, string nomeUtente, string cognomeUtente)
        {
            Console.WriteLine("\n*****Riepilogo Dati*****\n");
            Console.WriteLine($"Nome: \t\t{nomeUtente}");
            Console.WriteLine($"Cognome: \t{cognomeUtente}");
            Console.WriteLine($"Consumo: \t{consumo} kwH");
            Console.WriteLine($"Costo bolletta: {costo} euro");
        }
    }
}
