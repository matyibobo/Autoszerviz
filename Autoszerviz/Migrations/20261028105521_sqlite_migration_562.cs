using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autoszerviz.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_562 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Ugyfelek",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefon",
                table: "Ugyfelek",
                type: "INTEGER",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);
        }
    }
}
