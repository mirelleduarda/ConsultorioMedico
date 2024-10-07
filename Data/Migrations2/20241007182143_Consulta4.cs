using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    /// <inheritdoc />
    public partial class Consulta4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pacienteUF",
                table: "Consultas",
                newName: "pacienteUFID");

            migrationBuilder.RenameColumn(
                name: "pacienteCidade",
                table: "Consultas",
                newName: "pacienteCidadeID");

            migrationBuilder.RenameColumn(
                name: "medicoEspecialidade",
                table: "Consultas",
                newName: "medicoEspecialidadeID");

            migrationBuilder.AddColumn<int>(
                name: "cidadeID",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "especialidadeID",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_cidadeID",
                table: "Consultas",
                column: "cidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_especialidadeID",
                table: "Consultas",
                column: "especialidadeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Cidades_cidadeID",
                table: "Consultas",
                column: "cidadeID",
                principalTable: "Cidades",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Especialidades_especialidadeID",
                table: "Consultas",
                column: "especialidadeID",
                principalTable: "Especialidades",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Cidades_cidadeID",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Especialidades_especialidadeID",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_cidadeID",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_especialidadeID",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "cidadeID",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "especialidadeID",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "pacienteUFID",
                table: "Consultas",
                newName: "pacienteUF");

            migrationBuilder.RenameColumn(
                name: "pacienteCidadeID",
                table: "Consultas",
                newName: "pacienteCidade");

            migrationBuilder.RenameColumn(
                name: "medicoEspecialidadeID",
                table: "Consultas",
                newName: "medicoEspecialidade");
        }
    }
}
