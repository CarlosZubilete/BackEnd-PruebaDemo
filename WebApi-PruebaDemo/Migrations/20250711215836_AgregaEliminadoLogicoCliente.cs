using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_PruebaDemo.Migrations
{
    /// <inheritdoc />
    public partial class AgregaEliminadoLogicoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "clientes");
        }
    }
}
