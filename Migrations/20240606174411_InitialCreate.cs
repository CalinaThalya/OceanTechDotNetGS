using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanTechDotNetGS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_octh_empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nomeEmpresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nomeFantasia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_octh_empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_octh_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_octh_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_octh_empresaUsuario",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_octh_empresaUsuario", x => new { x.EmpresaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_tb_octh_empresaUsuario_tb_octh_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tb_octh_empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_octh_empresaUsuario_tb_octh_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_octh_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_octh_registroUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_octh_registroUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_octh_registroUsuario_tb_octh_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_octh_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_octh_registroVazamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RegistroUsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_octh_registroVazamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_octh_registroVazamento_tb_octh_registroUsuario_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "tb_octh_registroUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_octh_empresaUsuario_UsuarioId",
                table: "tb_octh_empresaUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_octh_registroUsuario_UsuarioId",
                table: "tb_octh_registroUsuario",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_octh_registroVazamento_RegistroUsuarioId",
                table: "tb_octh_registroVazamento",
                column: "RegistroUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_octh_empresaUsuario");

            migrationBuilder.DropTable(
                name: "tb_octh_registroVazamento");

            migrationBuilder.DropTable(
                name: "tb_octh_empresa");

            migrationBuilder.DropTable(
                name: "tb_octh_registroUsuario");

            migrationBuilder.DropTable(
                name: "tb_octh_usuario");
        }
    }
}
