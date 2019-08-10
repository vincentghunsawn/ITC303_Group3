using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreFitness.Migrations
{
    public partial class ShoppingCartChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderQty",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<string>(
                name: "ProductPrice",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "OrderQty",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionID",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
