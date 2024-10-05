using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioMedico.Data.Migrations2
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cids",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cids", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    qtdeEstoque = table.Column<int>(type: "int", nullable: false),
                    estoqueMin = table.Column<int>(type: "int", nullable: false),
                    estoqueMax = table.Column<int>(type: "int", nullable: false),
                    precoUnitario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cids");

            migrationBuilder.DropTable(
                name: "Medicamentos");
        }
    }
}
