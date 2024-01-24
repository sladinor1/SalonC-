using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecninca.Models
{
    public class MateriaEstudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required()]
        public int MateriasId { get; set; }

        [Required()]
        public int EstudiantesId { get; set; }

        public Estudiantes Estudiantes { get; set; }

        public Materias Materias { get; set; }
    }
}
