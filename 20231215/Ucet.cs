using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231215
{
    internal class Ucet
    {
        private string majitel;
        private int cislo;
        private Transakce transakce;

        public Ucet(string majitel, int cislo, Transakce transakce)
        {
            this.Majitel = majitel;
            this.Cislo = cislo;
            this.Transakce = transakce;
        }

        public string Majitel { get => majitel; set => majitel = value; }
        public int Cislo { get => cislo; set => cislo = value; }
        internal Transakce Transakce { get => transakce; set => transakce = value; }
    }
}
