using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PruebaTecninca.Models
{
    public class Materias
    {
        // Llave primaria autogenerada
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required()]
        [StringLength(50, ErrorMessage = "Rango debe ser entre 1 y 50 caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
