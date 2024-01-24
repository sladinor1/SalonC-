using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecninca.Models
{
    public class MateriaProfesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required()]
        public int MateriasId { get; set; }

        [Required()]
        public int ProfesoresId { get; set; }

        public Profesores Profesores { get; set; }

        public Materias Materias { get; set; }
    }
}
