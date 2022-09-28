using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyProduct_Exercise_03.Migrations
{
    public partial class removedduniqueKeyfromAssignParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty");

            migrationBuilder.DropIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty");

            migrationBuilder.DropIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty",
                column: "PartyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty",
                column: "ProductId",
                unique: true);
        }
    }
}
