using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroProductosDetalles.Migrations
{
    public partial class migracion_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    Ganancia = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalles",
                columns: table => new
                {
                    ProductosDetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductosId = table.Column<int>(type: "INTEGER", nullable: false),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalles", x => x.ProductosDetallesId);
                    table.ForeignKey(
                        name: "FK_ProductosDetalles_productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalles_ProductosId",
                table: "ProductosDetalles",
                column: "ProductosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosDetalles");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
