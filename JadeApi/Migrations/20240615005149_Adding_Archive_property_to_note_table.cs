using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JadeApi.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Archive_property_to_note_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archive",
                table: "Note",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archive",
                table: "Note");
        }
    }
}
