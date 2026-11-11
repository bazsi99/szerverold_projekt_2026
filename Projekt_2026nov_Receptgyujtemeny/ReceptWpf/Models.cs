using System;
using System.Collections.Generic;
using System.Text;

namespace ReceptWpf
{
    public class Recept
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string EtelTipus { get; set; }
        public string Leiras { get; set; }
        public int ElkeszitesiIdoPerc { get; set; }
        public DateTime Letrehozva { get; set; }
        public List<ReceptHozzavalo> Hozzavalok { get; set; }
    }

    public class Hozzavalo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
    }

    public class ReceptHozzavalo
    {
        public int ReceptId { get; set; }
        public int HozzavaloId { get; set; }
        public decimal Mennyiseg { get; set; }
        public string Mertekegyseg { get; set; }
        public Hozzavalo Hozzavalo { get; set; }

        public string Szoveg
        {
            get
            {
                if (Hozzavalo == null) return "";
                return Mennyiseg + " " + Mertekegyseg + " " + Hozzavalo.Nev;
            }
        }
    }
}
