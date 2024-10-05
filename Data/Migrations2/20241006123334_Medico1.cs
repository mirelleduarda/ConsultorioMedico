using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    /// <inheritdoc />
    public partial class Medico1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    especialidadeID = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    cidadeID = table.Column<int>(type: "int", nullable: false),
                    UFID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medicos_Cidades_cidadeID",
                        column: x => x.cidadeID,
                        principalTable: "Cidades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_especialidadeID",
                        column: x => x.especialidadeID,
                        principalTable: "Especialidades",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_cidadeID",
                table: "Medicos",
                column: "cidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_especialidadeID",
                table: "Medicos",
                column: "especialidadeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
