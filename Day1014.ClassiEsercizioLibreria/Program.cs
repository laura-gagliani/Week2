using System;
using System.Collections.Generic;

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

            Menu.Start();       //quando chiamo il metodo Start della classe Menu lui salta all'altro file e va a vedere cosa fare


            #region costruzione di oggetti
            Libro libro1 = new Libro(); //dove Libro() è il costruttore.
                                          //io sto dicendo costruiscimi una oggetto esempioDiLibro del "tipo" Libro, la classe che ho costruito
                                          //il costruttore prepara un pezzo di memoria per metterci tutti i dati che abbiamo preparato per la classe

            //assegnazione dei valori alle proprietà
            libro1.Codice = "Codice001alfanumerico"; //nome.Proprietà
            libro1.Autore = "Collodi";
            libro1.Titolo = "Pinocchio";
            libro1.Prezzo = 12.20;
            libro1.DataPubblicazione = new DateTime(1883);

            Console.WriteLine(libro1.Autore);

            Libro libro2 = new Libro();

            libro2.Codice = "jefkksj3t4tkfd";
            libro2.Autore = "Alessandro Manzoni";
            libro2.Prezzo = 9.99;
            //e così via
            #endregion

            #region lista
            List<Libro> listaDiLibri = new List<Libro>(); //creo una lista che può contenere oggetti "Libro"
                                                          //non devo specificare la dimensione

            listaDiLibri.Add(libro1);
            Console.WriteLine($"La lista contiene {listaDiLibri.Count} libri");
            listaDiLibri.Add(libro2);
            Console.WriteLine($"La lista contiene {listaDiLibri.Count} libri");

            listaDiLibri.Remove(libro1);
            Console.WriteLine($"La lista contiene {listaDiLibri.Count} libri");

            #endregion





        }
    }
}
