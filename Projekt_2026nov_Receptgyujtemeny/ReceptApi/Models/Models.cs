using System.ComponentModel.DataAnnotations.Schema;

namespace ReceptApi.Models
{
    [Table("receptek")]
    public class Recept
    {
        [Column("id")] public int Id { get; set; }
        [Column("nev")] public string Nev { get; set; }
        [Column("etel_tipus")] public string EtelTipus { get; set; }
        [Column("leiras")] public string Leiras { get; set; }
        [Column("elkeszitesi_ido_perc")] public int ElkeszitesiIdoPerc { get; set; }
        [Column("letrehozva")] public DateTime Letrehozva { get; set; }

        public List<ReceptHozzavalo> Hozzavalok { get; set; }
    }

    [Table("hozzavalok")]
    public class Hozzavalo
    {
        [Column("id")] public int Id { get; set; }
        [Column("nev")] public string Nev { get; set; }
    }

    [Table("recept_hozzavalok")]
    public class ReceptHozzavalo
    {
        [Column("recept_id")] public int ReceptId { get; set; }
        [Column("hozzavalo_id")] public int HozzavaloId { get; set; }
        [Column("mennyiseg")] public decimal Mennyiseg { get; set; }
        [Column("mertekegyseg")] public string Mertekegyseg { get; set; }

        public Hozzavalo Hozzavalo { get; set; }
    }
}