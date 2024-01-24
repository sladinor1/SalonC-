using System.ComponentModel.DataAnnotations;

namespace PruebaTecninca.Models
{
    public class ViewEstudiantes
    {
        [Key]
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

    }
}
