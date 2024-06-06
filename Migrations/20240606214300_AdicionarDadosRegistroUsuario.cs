using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanTechDotNetGS.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosRegistroUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_octh_registroUsuario",
                columns: new[] { "Id", "UsuarioId", "NovaColuna" },
                values: new object[,]
                {
                    { 1, 1, "Valor1" },
                    { 2, 2, "Valor2" },
                    // Adicione mais linhas conforme necessário
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_octh_registroUsuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_octh_registroUsuario",
                keyColumn: "Id",
                keyValue: 2);

        }
    }
}
