using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Un libro è un'entità che ha
//Codice
//Titolo
//Autore
//Genere
//Prezzo
//Data di pubblicazione

namespace Day1014.ClassiEsercizioLibreria
{
    public class Libro //consiglio di mettere public (come dire "visibile") davanti alla parola class
    {


        //qui dobbiamo scrivere le proprietà che vogliamo dare alla classe: "prop + doppio TAB" e inizia la struttura

        public string Codice { get; set; }  //le proprietà si chiamano con la Maiuscola
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public Genere Genere { get; set; }  //vogliamo usare l'enum: così gli abbiamo detto che il tipo è "Genere" (che devo definire io!!)
        public double Prezzo { get; set; }
        public DateTime DataPubblicazione { get; set; }

        //oltre alle Proprietà va messo anche un Costruttore, ovvero uno strumento che serve per costruire oggetti Libro:

        public Libro() //si chiama come la classe; non prende niente e non dà niente
        {

        }


    }

    public enum Genere
    {
        Narrativa,      //scrivo una lista di termini a cui lui associa numeri partendo automaticamente da 0
        Storico,        //posso anche forzare una numerazione a piacere
        Fantasy,
        Saggistica,
        Classici
    }
}
