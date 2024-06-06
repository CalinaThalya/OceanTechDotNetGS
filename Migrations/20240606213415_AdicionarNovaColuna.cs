using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanTechDotNetGS.Migrations
{
    public partial class AdicionarNovaColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NovaColuna",
                table: "tb_octh_registroUsuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NovaColuna",
                table: "tb_octh_registroUsuario");
        }
    }
}
