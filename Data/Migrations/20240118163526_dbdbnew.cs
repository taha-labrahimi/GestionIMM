using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionIMM.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbdbnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponibilite",
                table: "contratLocations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponibilite",
                table: "contratLocations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
