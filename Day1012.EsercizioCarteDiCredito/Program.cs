using System;

namespace Day1012.EsercizioCarteDiCredito
{
    class Program
    {
        static void Main(string[] args)
        {
            // Le carte di pagamento sono lunghe 16 cifre.
            // Le prime 6 cifre rappresentano un numero di identificazione univoco per la banca che ha emesso la carta.
            // Le successive 2 cifre determinano il tipo di carta (ad es. debito, credito, regalo).
            // Le cifre da 9 a 15 sono il numero di serie della carta
            // L'ultima cifra è utilizzata come cifra di controllo per verificare se il numero della carta è valido.

            //NB LA DISPARI DELL'ARRAY NON è LA DISPARI DELLA CARTA

            // Hans Peter ha inventato un metodo per determinare se un numero di carta di credito è sintatticamente valido

            // Step 1 : Vengono raddoppiate le cifre che si trovano in posizione dispari e
            // Step 2 : Se questo "raddoppio" risulta in un numero a due cifre, viene sottratto 9 da esso per ottenere una sola cifra.
            // Step 3 : Vengono sommante tutte le cifre ottenute (quelle raddoppiate)
            // Step 4 : Vengono aggiunte le cifre nelle posizioni pari
            // Step 5 : Se il risultato è divisibile per 10, il numero della carta è valido; in caso contrario, non è valido.


            // Esempi
            // Carta di pagamento   : 4 5 5 6 7 3 7 5 8 6 8 9 9 8 5 5
            // Step 1               : 8 5 10 6 14 3 14 5 16 6 16 9 18 8 10 5
            // Step 2               : 8 5 1 6 5 3 5 5 7 6 7 9 9 8 1 5
            // Step 3               : 8 + 1 + 5 + 5 + 7 + 7 + 9 + 1 = 43
            // Step 4               : 43 + (5+6+3+5+6+9+8+5) = 43 + 47 = 90
            // Step 5 : 90/10 = 9 resto 0 -> Numero della carta valido


            // Esempi
            // Carta di pagamento : 4 0 2 4 0 0 7 1 0 9 0 2 2 1 4 3
            // Step 1 : 8 0 4 4 0 0 14 1 0 9 0 2 4 1 8 3
            // Step 2 : 8 0 4 4 0 0 5 1 0 9 0 2 4 1 8 3
            // Step 3 : 8 + 4 + 0 + 5 + 0 + 0 + 4 + 8 = 29
            // Step 4 : 29 + (0+4+0+1+9+2+1+3) = 29 + 20 = 49
            // Step 5 : 49/10 = 4 resto 9 -> Numero della carta non valido


            int[] cifreCarta = InserisciArray();

            //int[] cifreCartaMod = RaddoppiaEControllaCifreDispari(cifreCarta);
            //int sommaCifre = SommaElementiArray(cifreCartaMod);
            //Console.WriteLine(ControllaValidità(sommaCifre));

            int[] posizioniDispari = ArrayDispariRaddoppiatoControllato(cifreCarta);
            int[] posizioniPari = ArrayPari(cifreCarta);
            int sommaPari = SommaElementiArray(posizioniPari);
            int sommaDispari = SommaElementiArray(posizioniDispari);
            Console.WriteLine(ControllaValidità(sommaPari + sommaDispari));
        }

        private static int[] InserisciArray()
        {
            int[] cifreCarta = new int[16];
            Console.WriteLine("Inserisci le cifre della tua carta:");

            for (int i = 0; i < cifreCarta.Length; i++)
            {
                bool cifraCorretta = int.TryParse(Console.ReadLine(), out int cifra);
                while ((!cifraCorretta) && cifra <0 && cifra >9)
                {
                    Console.WriteLine("Errore! Reinserire l'ultima cifra");
                    cifraCorretta = int.TryParse(Console.ReadLine(), out cifra);
                };

                cifreCarta[i] = cifra;

            }
            return cifreCarta;
        }

        private static bool ConfermaInserimentoArray(int[] array)
        {
            bool corretto = false;
            Console.WriteLine("Le cifre inserite sono:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}  ");
            }
            Console.WriteLine("Premi y per confermare, n per inserire una nuova carta");
            //booleano a seconda
            return corretto;
        }

        private static int[] RaddoppiaEControllaCifreDispari(int[] array)
        {
            int[] arrayMod = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)   // se la i.esima posizione è pari -> cifra DISPARI della carta
                {
                    arrayMod[i] = 2 * array[i];
                    if (arrayMod[i] >= 10)
                    {
                        arrayMod[i] = arrayMod[i] - 9;
                    }
                }
                else if (i % 2 != 0) //se la iesima posizione è dispari ->cifra PARI della carta
                {
                    arrayMod[i] = array[i];
                }
            }

            return arrayMod;
        }

        private static int SommaElementiArray(int[] array)
        {
            int somma = 0;

            for (int i = 0; i< array.Length; i++)
            {
                somma = somma + array[i];
            }

            return somma;
        }

        private static string ControllaValidità(int somma)
        {
            string validità = null;
            if(somma%10 == 0)
            {
                validità = "Numero della carta valido";
            }
            else if (somma%10 != 0)
            {
                validità = "Numero della carta non valido";
            }

            return validità;
        }




        private static int[] ArrayDispariRaddoppiatoControllato(int[] array)
        {
            int[] dispari = new int[array.Length / 2];
            int posizione = 0;
            
            for (int i =0; i < array.Length; i = i + 2)
            {
                dispari[posizione] = array[i];
                if (dispari[posizione]>= 10)
                {
                    dispari[posizione] = dispari[posizione] - 9;
                }

                    posizione++;

            }

            return dispari;
        }

        private static int[] ArrayPari(int[] array)
        {
            int[] pari = new int[array.Length / 2];
            int posizione = 0;

            for (int i = 1; i < array.Length; i = i + 2)
            {
                pari[posizione] = array[i];
                posizione++;

            }

            return pari;
        }
    }
}
