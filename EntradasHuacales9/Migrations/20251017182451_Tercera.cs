using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntradasHuacales9.Migrations
{
    /// <inheritdoc />
    public partial class Tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasHuacalesTiposHuacales");

            migrationBuilder.CreateIndex(
                name: "IX_entradasHuacalesDetalles_TipoId",
                table: "entradasHuacalesDetalles",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_entradasHuacalesDetalles_TiposHuacales_TipoId",
                table: "entradasHuacalesDetalles",
                column: "TipoId",
                principalTable: "TiposHuacales",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entradasHuacalesDetalles_TiposHuacales_TipoId",
                table: "entradasHuacalesDetalles");

            migrationBuilder.DropIndex(
                name: "IX_entradasHuacalesDetalles_TipoId",
                table: "entradasHuacalesDetalles");

            migrationBuilder.CreateTable(
                name: "EntradasHuacalesTiposHuacales",
                columns: table => new
                {
                    TipoHuacaleTipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesTiposHuacales", x => new { x.TipoHuacaleTipoId, x.TipoId });
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesTiposHuacales_EntradasHuacales_TipoId",
                        column: x => x.TipoId,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesTiposHuacales_TiposHuacales_TipoHuacaleTipoId",
                        column: x => x.TipoHuacaleTipoId,
                        principalTable: "TiposHuacales",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesTiposHuacales_TipoId",
                table: "EntradasHuacalesTiposHuacales",
                column: "TipoId");
        }
    }
}
