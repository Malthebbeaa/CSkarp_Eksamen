using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RettetForetagne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntalForetagedeUdleveringer",
                table: "Ordinationer",
                newName: "AntalForetagneUdleveringer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntalForetagneUdleveringer",
                table: "Ordinationer",
                newName: "AntalForetagedeUdleveringer");
        }
    }
}
