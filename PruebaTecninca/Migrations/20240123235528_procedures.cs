using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecninca.Migrations
{
    /// <inheritdoc />
    public partial class procedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.ObtenerEstudiantes
AS
BEGIN
SELECT Id, Identificacion, Nombres, Apellidos 
FROM Estudiantes   
END;
GO

CREATE PROCEDURE dbo.ObtenerProfesores
AS
BEGIN
SELECT Id, Identificacion, Nombres, Apellidos 
FROM Profesores   
END;
GO

CREATE PROCEDURE dbo.ObtenerMaterias
AS
BEGIN
SELECT Id,Nombre 
FROM Materias   
END;
GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
