using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecninca.Models
{
    [Index(nameof(Identificacion), IsUnique = true)]
    public class Estudiantes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required()]
        [StringLength(50, ErrorMessage = "Rango debe ser entre 1 y 50 caracteres", MinimumLength = 1)]
        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }

        [Required()]
        [StringLength(50, ErrorMessage = "Rango debe ser entre 1 y 50 caracteres", MinimumLength = 1)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Rango debe ser entre 1 y 50 caracteres no numericos", MinimumLength = 1)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
    }
}
