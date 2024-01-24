using Microsoft.EntityFrameworkCore;
using PruebaTecninca.Models;
using System;
using System.Reflection.Metadata;

namespace PruebaTecninca.Data
{
    public class Clase_Context : DbContext
    {
        public Clase_Context(DbContextOptions<Clase_Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ViewEstudiantes>()
                .ToSqlQuery("EXEC ObtenerEstudiantes");

            modelBuilder.Entity<ViewProfesores>()
                .ToSqlQuery("EXEC ObtenerProfesores");

            modelBuilder.Entity<ViewMaterias>()
                .ToSqlQuery("EXEC ObtenerMaterias");

            modelBuilder.Entity<MateriaEstudiante>()
                .HasKey(e => new { e.MateriasId , e.EstudiantesId });

            modelBuilder.Entity<MateriaProfesor>()
                .HasKey(e => new { e.MateriasId, e.ProfesoresId });
        }

        public DbSet<PruebaTecninca.Models.Estudiantes> Estudiantes { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.Profesores> Profesores { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.Materias> Materias { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.MateriaProfesor> MateriaProfesor { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.MateriaEstudiante> MateriaEstudiante { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.ViewEstudiantes> ViewEstudiantes { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.ViewMaterias> ViewMaterias { get; set; } = default!;
        public DbSet<PruebaTecninca.Models.ViewProfesores> ViewProfesores { get; set; } = default!;

    }
}
