using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecninca.Migrations
{
    /// <inheritdoc />
    public partial class tablesupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MateriaProfesor",
                table: "MateriaProfesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MateriaEstudiante",
                table: "MateriaEstudiante");

            migrationBuilder.DropColumn(
                name: "Id_Materia",
                table: "MateriaProfesor");

            migrationBuilder.DropColumn(
                name: "Id_Profesor",
                table: "MateriaProfesor");

            migrationBuilder.DropColumn(
                name: "Id_Estudiante",
                table: "MateriaEstudiante");

            migrationBuilder.DropColumn(
                name: "Id_Materia",
                table: "MateriaEstudiante");

            migrationBuilder.AddColumn<int>(
                name: "MateriasId",
                table: "MateriaProfesor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfesoresId",
                table: "MateriaProfesor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriasId",
                table: "MateriaEstudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstudiantesId",
                table: "MateriaEstudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MateriaProfesor",
                table: "MateriaProfesor",
                columns: new[] { "MateriasId", "ProfesoresId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MateriaEstudiante",
                table: "MateriaEstudiante",
                columns: new[] { "MateriasId", "EstudiantesId" });


            migrationBuilder.CreateIndex(
                name: "IX_Profesores_Identificacion",
                table: "Profesores",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfesor_ProfesoresId",
                table: "MateriaProfesor",
                column: "ProfesoresId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaEstudiante_EstudiantesId",
                table: "MateriaEstudiante",
                column: "EstudiantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_Identificacion",
                table: "Estudiantes",
                column: "Identificacion",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaEstudiante_Estudiantes_EstudiantesId",
                table: "MateriaEstudiante",
                column: "EstudiantesId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaEstudiante_Materias_MateriasId",
                table: "MateriaEstudiante",
                column: "MateriasId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfesor_Materias_MateriasId",
                table: "MateriaProfesor",
                column: "MateriasId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriaProfesor_Profesores_ProfesoresId",
                table: "MateriaProfesor",
                column: "ProfesoresId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriaEstudiante_Estudiantes_EstudiantesId",
                table: "MateriaEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaEstudiante_Materias_MateriasId",
                table: "MateriaEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfesor_Materias_MateriasId",
                table: "MateriaProfesor");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriaProfesor_Profesores_ProfesoresId",
                table: "MateriaProfesor");

            migrationBuilder.DropIndex(
                name: "IX_Profesores_Identificacion",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MateriaProfesor",
                table: "MateriaProfesor");

            migrationBuilder.DropIndex(
                name: "IX_MateriaProfesor_ProfesoresId",
                table: "MateriaProfesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MateriaEstudiante",
                table: "MateriaEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_MateriaEstudiante_EstudiantesId",
                table: "MateriaEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_Identificacion",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "MateriasId",
                table: "MateriaProfesor");

            migrationBuilder.DropColumn(
                name: "ProfesoresId",
                table: "MateriaProfesor");

            migrationBuilder.DropColumn(
                name: "MateriasId",
                table: "MateriaEstudiante");

            migrationBuilder.DropColumn(
                name: "EstudiantesId",
                table: "MateriaEstudiante");

            migrationBuilder.AddColumn<string>(
                name: "Id_Materia",
                table: "MateriaProfesor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id_Profesor",
                table: "MateriaProfesor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id_Estudiante",
                table: "MateriaEstudiante",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id_Materia",
                table: "MateriaEstudiante",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MateriaProfesor",
                table: "MateriaProfesor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MateriaEstudiante",
                table: "MateriaEstudiante",
                column: "Id");
        }
    }
}
