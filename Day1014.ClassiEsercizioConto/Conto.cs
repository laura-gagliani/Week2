using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1014.ClassiEsercizioConto
{
    public class Conto
    {
        public string NomeIntestatario { get; set; }
        public string CognomeIntestatario { get; set; }
        public string CoordinateBancarie { get; set; }
        public int TipoDiConto { get; set; }
        public double SaldoConto { get; set; }
    }

    public enum TipoDiConto
    {
        ContoCorrente,
        ContoDiRisparmio
    }
}
