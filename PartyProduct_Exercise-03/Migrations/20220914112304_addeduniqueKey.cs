using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyProduct_Exercise_03.Migrations
{
    public partial class addeduniqueKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductRate_ProductId",
                table: "ProductRate");

            migrationBuilder.DropIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty");

            migrationBuilder.DropIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "Party",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_ProductId",
                table: "ProductRate",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductName",
                table: "Product",
                column: "ProductName",
                unique: true,
                filter: "[ProductName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Party_PartyName",
                table: "Party",
                column: "PartyName",
                unique: true,
                filter: "[PartyName] IS NOT NULL");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductRate_ProductId",
                table: "ProductRate");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductName",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Party_PartyName",
                table: "Party");

            migrationBuilder.DropIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty");

            migrationBuilder.DropIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PartyName",
                table: "Party",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_ProductId",
                table: "ProductRate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_PartyId",
                table: "AssignParty",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignParty_ProductId",
                table: "AssignParty",
                column: "ProductId");
        }
    }
}
