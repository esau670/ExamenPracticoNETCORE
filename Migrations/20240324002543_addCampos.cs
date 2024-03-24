using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaEncuesta.Migrations
{
    /// <inheritdoc />
    public partial class addCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Encuestas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Valor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valor_Campo_CampoId",
                        column: x => x.CampoId,
                        principalTable: "Campo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valor_CampoId",
                table: "Valor",
                column: "CampoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valor");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Encuestas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
