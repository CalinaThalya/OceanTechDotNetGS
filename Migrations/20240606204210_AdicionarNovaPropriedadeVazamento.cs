using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanTechDotNetGS.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarNovaPropriedadeVazamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_octh_registroVazamento_tb_octh_registroUsuario_RegistroUsuarioId",
                table: "tb_octh_registroVazamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_octh_registroVazamento",
                table: "tb_octh_registroVazamento");

            migrationBuilder.RenameTable(
                name: "tb_octh_registroVazamento",
                newName: "tb_octh_registroVazamentos");

            migrationBuilder.RenameIndex(
                name: "IX_tb_octh_registroVazamento_RegistroUsuarioId",
                table: "tb_octh_registroVazamentos",
                newName: "IX_tb_octh_registroVazamentos_RegistroUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_octh_registroVazamentos",
                table: "tb_octh_registroVazamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_octh_registroVazamentos_tb_octh_registroUsuario_RegistroUsuarioId",
                table: "tb_octh_registroVazamentos",
                column: "RegistroUsuarioId",
                principalTable: "tb_octh_registroUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_octh_registroVazamentos_tb_octh_registroUsuario_RegistroUsuarioId",
                table: "tb_octh_registroVazamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_octh_registroVazamentos",
                table: "tb_octh_registroVazamentos");

            migrationBuilder.RenameTable(
                name: "tb_octh_registroVazamentos",
                newName: "tb_octh_registroVazamento");

            migrationBuilder.RenameIndex(
                name: "IX_tb_octh_registroVazamentos_RegistroUsuarioId",
                table: "tb_octh_registroVazamento",
                newName: "IX_tb_octh_registroVazamento_RegistroUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_octh_registroVazamento",
                table: "tb_octh_registroVazamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_octh_registroVazamento_tb_octh_registroUsuario_RegistroUsuarioId",
                table: "tb_octh_registroVazamento",
                column: "RegistroUsuarioId",
                principalTable: "tb_octh_registroUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
