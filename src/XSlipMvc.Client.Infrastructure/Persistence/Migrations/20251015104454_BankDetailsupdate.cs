using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XSlipMvc.Client.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BankDetailsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Banks");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "BankDetails",
                type: "nvarchar(15)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "BankDetails");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Banks",
                type: "nvarchar(15)",
                nullable: true);
        }
    }
}
