using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pruebaaas.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductoPrecioUnitario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "Productos");
        }
    }
}
