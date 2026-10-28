using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autoszerviz.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_177 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FelvetelDatuba",
                table: "Javitasok",
                newName: "FelvetelDatuma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FelvetelDatuma",
                table: "Javitasok",
                newName: "FelvetelDatuba");
        }
    }
}
