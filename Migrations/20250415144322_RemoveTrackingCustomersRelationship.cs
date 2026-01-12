using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postal_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrackingCustomersRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageTracking_Customers_custID",
                table: "PackageTracking");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageTracking_Employees_EmployeeID",
                table: "PackageTracking");

            migrationBuilder.DropIndex(
                name: "IX_PackageTracking_custID",
                table: "PackageTracking");

            migrationBuilder.DropIndex(
                name: "IX_PackageTracking_EmployeeID",
                table: "PackageTracking");

            migrationBuilder.AlterColumn<string>(
                name: "custID",
                table: "PackageTracking",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "PackageTracking",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CustomersCustID",
                table: "PackageTracking",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageTracking_CustomersCustID",
                table: "PackageTracking",
                column: "CustomersCustID");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageTracking_Customers_CustomersCustID",
                table: "PackageTracking",
                column: "CustomersCustID",
                principalTable: "Customers",
                principalColumn: "CustID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageTracking_Customers_CustomersCustID",
                table: "PackageTracking");

            migrationBuilder.DropIndex(
                name: "IX_PackageTracking_CustomersCustID",
                table: "PackageTracking");

            migrationBuilder.DropColumn(
                name: "CustomersCustID",
                table: "PackageTracking");

            migrationBuilder.AlterColumn<string>(
                name: "custID",
                table: "PackageTracking",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "PackageTracking",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTracking_custID",
                table: "PackageTracking",
                column: "custID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageTracking_EmployeeID",
                table: "PackageTracking",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageTracking_Customers_custID",
                table: "PackageTracking",
                column: "custID",
                principalTable: "Customers",
                principalColumn: "CustID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageTracking_Employees_EmployeeID",
                table: "PackageTracking",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
