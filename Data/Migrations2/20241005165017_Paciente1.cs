using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    /// <inheritdoc />
    public partial class Paciente1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    cidadeID = table.Column<int>(type: "int", nullable: false),
                    UFID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pacientes_Cidades_cidadeID",
                        column: x => x.cidadeID,
                        principalTable: "Cidades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_cidadeID",
                table: "Pacientes",
                column: "cidadeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
