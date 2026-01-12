using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postal_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomerPackagesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageDetails_Customers_CustomersCustID",
                table: "PackageDetails");

            migrationBuilder.DropIndex(
                name: "IX_PackageDetails_CustomersCustID",
                table: "PackageDetails");

            migrationBuilder.DropColumn(
                name: "CustomersCustID",
                table: "PackageDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomersCustID",
                table: "PackageDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetails_CustomersCustID",
                table: "PackageDetails",
                column: "CustomersCustID");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageDetails_Customers_CustomersCustID",
                table: "PackageDetails",
                column: "CustomersCustID",
                principalTable: "Customers",
                principalColumn: "CustID");
        }
    }
}
