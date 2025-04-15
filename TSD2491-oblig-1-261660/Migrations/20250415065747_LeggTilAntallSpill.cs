using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSD2491_oblig_1_261660.Migrations
{
    /// <inheritdoc />
    public partial class LeggTilAntallSpill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Spill",
                table: "Bruker",
                newName: "AntallSpill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntallSpill",
                table: "Bruker",
                newName: "Spill");
        }
    }
}
