using System.ComponentModel.DataAnnotations;

namespace PruebaTecninca.Models
{
    public class ViewMaterias
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
