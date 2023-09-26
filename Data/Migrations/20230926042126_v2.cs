using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auth.studies.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ToDos",
                newName: "LastUpdatedAt");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "ToDos",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdatedAt",
                table: "ToDos",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ToDos",
                newName: "EndDate");
        }
    }
}
