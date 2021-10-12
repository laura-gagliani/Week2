using System;
using System.IO;

namespace Day1012.ScritturaLetturaDaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //la prima cosa da fare è specificare il percorso che ci porta al file dove vogliamo
            //scrivere le nostre cose
            //string path = @"F:\Laura\Documenti\Avanade\Academy\Week2\Day1012.ScritturaLetturaDaFile"; //@ per non far considerare eventuali caratteri speciali

            //StreamWriter sw = new StreamWriter(@"fileProva.txt"); //se non specifico, in questo modo, il percorso lui mi crea il file nella cartella bin del progetto

            string path = @"F:\Laura\Documenti\Avanade\Academy\Week2\Day1012.ScritturaLetturaDaFile\fileProva.txt";
            
            
            //scrittura su file con chiusura manuale. tutto quello che gli dico di fare lo fa sul file, non sulla console
            
            StreamWriter sw = new StreamWriter(path); //in questa maniera invece crea il file dove gli dico io

            sw.WriteLine("Ciao, frase di esempio"); 
            sw.WriteLine("Posso scrivere quello che mi pare");

            sw.Close();         //comando di chiusura manuale


            //posso anche scrivere con chiusura automatica -> using
            //scrittura su file sovrascrivendo il contenuto precedente

            using (StreamWriter sw1 = new StreamWriter(path))       //devo cambiare nome della variabile?
            {
                sw1.WriteLine("Esempio di sovrascrittura");
            }

            //se invece voglio mantenere il contenuto precedente, non sovrascrivere

            using(StreamWriter sw1 = new StreamWriter(path, true))
            {
                sw1.WriteLine("Con questo sto aggiungendo");
            }

            //adesso invece vogliamo leggere tutto il file

            using(StreamReader sr1 =new StreamReader(path))
            {
               string contenutoFile = sr1.ReadToEnd();            //tutto quello che legge viene reso in un'unica stringa
            }

            //leggere la riga tal dei tali dal file
            using(StreamReader sr1= new StreamReader(path))
            {
                string contenutoRigaSingola = sr1.ReadLine();       //questo prende la prima riga
            }

            //lettura di tutto il file "riga per riga"
            using(StreamReader sr1 = new StreamReader(path))
            {
                string contenutoFileCompleto = sr1.ReadToEnd();
                var arrayDiRighe = contenutoFileCompleto.Split("\r\n");     //splitta nei vari posti dell'array secondo il separatore indicato
            }

            //NOMI DELLE VARIABILI STREAMREADER: posso dare lo stesso nome perché ognuna "nasce e muore" dentro il suo using.
        }
    }
}
