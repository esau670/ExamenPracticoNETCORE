using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaEncuesta.Migrations
{
    /// <inheritdoc />
    public partial class editModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campo_Encuestas_EncuestaId",
                table: "Campo");

            migrationBuilder.DropForeignKey(
                name: "FK_Valor_Campo_CampoId",
                table: "Valor");

            migrationBuilder.AlterColumn<int>(
                name: "CampoId",
                table: "Valor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EncuestaId",
                table: "Campo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campo_Encuestas_EncuestaId",
                table: "Campo",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Valor_Campo_CampoId",
                table: "Valor",
                column: "CampoId",
                principalTable: "Campo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campo_Encuestas_EncuestaId",
                table: "Campo");

            migrationBuilder.DropForeignKey(
                name: "FK_Valor_Campo_CampoId",
                table: "Valor");

            migrationBuilder.AlterColumn<int>(
                name: "CampoId",
                table: "Valor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EncuestaId",
                table: "Campo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Campo_Encuestas_EncuestaId",
                table: "Campo",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Valor_Campo_CampoId",
                table: "Valor",
                column: "CampoId",
                principalTable: "Campo",
                principalColumn: "Id");
        }
    }
}
