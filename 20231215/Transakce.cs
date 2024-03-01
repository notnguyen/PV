using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231215
{
    internal class Transakce
    {
        private DateTime date;
        private string info;
        private bool VkladVyber;
        private int protiCislo;
        private string variabilniSymbol;
        private string konstantniSymbol;
        private int castka;

        public Transakce(DateTime date, string info, bool vkladVyber, int protiCislo, string variabilniSymbol, string konstantniSymbol, int castka)
        {
            this.Date = date;
            this.Info = info;
            VkladVyber1 = vkladVyber;
            this.ProtiCislo = protiCislo;
            this.VariabilniSymbol = variabilniSymbol;
            this.KonstantniSymbol = konstantniSymbol;
            this.Castka = castka;
        }

        public DateTime Date { get => date; set => date = value; }
        public string Info { get => info; set => info = value; }
        public bool VkladVyber1 { get => VkladVyber; set => VkladVyber = value; }
        public int ProtiCislo { get => protiCislo; set => protiCislo = value; }
        public string VariabilniSymbol { get => variabilniSymbol; set => variabilniSymbol = value; }
        public string KonstantniSymbol { get => konstantniSymbol; set => konstantniSymbol = value; }
        public int Castka { get => castka; set => castka = value; }
    }
}
