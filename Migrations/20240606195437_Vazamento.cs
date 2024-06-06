using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanTechDotNetGS.Migrations
{
    /// <inheritdoc />
    public partial class Vazamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDetecao",
                table: "tb_octh_registroVazamento",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DescricaoVazamento",
                table: "tb_octh_registroVazamento",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoSeveridade",
                table: "tb_octh_registroVazamento",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDetecao",
                table: "tb_octh_registroVazamento");

            migrationBuilder.DropColumn(
                name: "DescricaoVazamento",
                table: "tb_octh_registroVazamento");

            migrationBuilder.DropColumn(
                name: "TipoSeveridade",
                table: "tb_octh_registroVazamento");
        }
    }
}
