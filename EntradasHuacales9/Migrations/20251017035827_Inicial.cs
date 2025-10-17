using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntradasHuacales9.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradasHuacales",
                columns: table => new
                {
                    IdEntrada = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Importe = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacales", x => x.IdEntrada);
                });

            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "entradasHuacalesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    IdEntrada = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradasHuacalesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_entradasHuacalesDetalles_EntradasHuacales_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Huacal verde pequeño", 0 },
                    { 2, "Huacal rojo pequeño", 0 },
                    { 3, "Huacal verde mediano", 0 },
                    { 4, "Huacal rojo mediano", 0 },
                    { 5, "Huacal verde Grande", 0 },
                    { 6, "Huacal rojo grande", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_entradasHuacalesDetalles_IdEntrada",
                table: "entradasHuacalesDetalles",
                column: "IdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesTiposHuacales_TipoId",
                table: "EntradasHuacalesTiposHuacales",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entradasHuacalesDetalles");

            migrationBuilder.DropTable(
                name: "EntradasHuacalesTiposHuacales");

            migrationBuilder.DropTable(
                name: "EntradasHuacales");

            migrationBuilder.DropTable(
                name: "TiposHuacales");
        }
    }
}
