using System.ComponentModel.DataAnnotations;

namespace Autoszerviz.Models
{
    public class Ugyfel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A név megadása kötelező!")]
        [MaxLength(100, ErrorMessage = "A név maximum 100 karakterből állhat!")]
        public string Nev { get; set; }
        [MaxLength(20, ErrorMessage = "A telefonszám maximum 20 karakterből állhat!")]
        public string Telefon { get; set; }
        [EmailAddress(ErrorMessage = "Érvénytelen email cím formátum!")]
        public string Email { get; set; }

        public IList<Javitas>? Javitasok { get; set; }
    }
}
