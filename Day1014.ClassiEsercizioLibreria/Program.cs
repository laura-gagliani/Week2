using System;

namespace Day1014.ClassiEsercizioLibreria
{
    class Program
    {
        static void Main(string[] args)
        {
            #region traccia
            //Scrivere un programma che gestisca una libreria.

            //Un libro è un'entità che ha
            //Codice
            //Titolo
            //Autore
            //Genere
            //Prezzo
            //Data di pubblicazione

            //Per il genere usare un enum

            //Sarà possibile inserire un nuovo libro, eliminare un libro, modificare un libro o cercare i libri per genere
            #endregion

            Libro libroTot = new Libro(); //dove Libro() è il costruttore.
                                          //io sto dicendo costruiscimi una oggetto esempioDiLibro del "tipo" Libro, la classe che ho costruito
                                          //il costruttore prepara un pezzo di memoria per metterci tutti i dati che abbiamo preparato per la classe

            libroTot.Codice = "Codice001alfanumerico"; //nome.Proprietà
            libroTot.Autore = "Collodi";
            libroTot.Titolo = "Pinocchio";
            libroTot.Prezzo = 12.20;
            libroTot.DataPubblicazione = new DateTime(1880);
        }
    }
}
