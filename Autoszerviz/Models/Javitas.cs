using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoszerviz.Models
{
    public class Javitas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Az ügyfél megadása kötelező!")]
        public int UgyfelId { get; set; }
        [Required(ErrorMessage = "A rendszám megadása kötelező!")]
        [MaxLength(10, ErrorMessage = "A rendszám maximum 10 karakterből állhat!")]
        public string Rendszam { get; set; }
        [MaxLength(300, ErrorMessage = "A leírás maximum 300 karakterből állhat!")]
        public string Leiras { get; set; }
        public decimal Koltseg { get; set; }
        public string Allapot { get; set; }
        public DateOnly FelvetelDatuba { get; set; }

        [ForeignKey(nameof(UgyfelId))]
        public Ugyfel Ugyfel { get; set; }
    }
}
