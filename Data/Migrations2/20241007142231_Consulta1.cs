using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    /// <inheritdoc />
    public partial class Consulta1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacienteID = table.Column<int>(nullable: false),
                    pacienteNome = table.Column<string>(nullable: true),
                    pacienteCidade = table.Column<string>(nullable: true),
                    pacienteUF = table.Column<string>(nullable: true),
                    medicoID = table.Column<int>(nullable: false),
                    medicoEspecialidade = table.Column<string>(nullable: true),
                    cidID = table.Column<int>(nullable: false),
                    medicamentoID = table.Column<int>(nullable: false),
                    qtdeMedicamento = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consultas_Cids_cidID",
                        column: x => x.cidID,
                        principalTable: "Cids",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicamentos_medicamentoID",
                        column: x => x.medicamentoID,
                        principalTable: "Medicamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_medicoID",
                        column: x => x.medicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_pacienteID",
                        column: x => x.pacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");
        }
    }
}
