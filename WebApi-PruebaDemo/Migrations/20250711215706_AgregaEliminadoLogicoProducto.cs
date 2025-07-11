using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_PruebaDemo.Migrations
{
    /// <inheritdoc />
    public partial class AgregaEliminadoLogicoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "productos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "productos");
        }
    }
}
