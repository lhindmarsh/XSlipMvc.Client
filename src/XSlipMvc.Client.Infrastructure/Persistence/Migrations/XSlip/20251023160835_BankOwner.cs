using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XSlipMvc.Client.Infrastructure.Persistence.Migrations.XSlip
{
    /// <inheritdoc />
    public partial class BankOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankOwner_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankOwner_ApplicationUserId_BankId",
                table: "BankOwner",
                columns: new[] { "ApplicationUserId", "BankId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankOwner_BankId",
                table: "BankOwner",
                column: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankOwner");
        }
    }
}
