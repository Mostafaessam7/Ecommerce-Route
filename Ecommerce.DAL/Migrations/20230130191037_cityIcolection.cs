using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.DAL.Migrations
{
    public partial class cityIcolection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_Countries_CountyId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_districts_cities_CityId",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_districts_DistrictId",
                table: "suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_districts",
                table: "districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "districts",
                newName: "District");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_districts_CityId",
                table: "District",
                newName: "IX_District_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_cities_CountyId",
                table: "City",
                newName: "IX_City_CountyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountyId",
                table: "City",
                column: "CountyId",
                principalTable: "Country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_District_City_CityId",
                table: "District",
                column: "CityId",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_District_DistrictId",
                table: "suppliers",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountyId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_District_City_CityId",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_District_DistrictId",
                table: "suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "districts");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "cities");

            migrationBuilder.RenameIndex(
                name: "IX_District_CityId",
                table: "districts",
                newName: "IX_districts_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountyId",
                table: "cities",
                newName: "IX_cities_CountyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_districts",
                table: "districts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_Countries_CountyId",
                table: "cities",
                column: "CountyId",
                principalTable: "Countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_districts_cities_CityId",
                table: "districts",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_districts_DistrictId",
                table: "suppliers",
                column: "DistrictId",
                principalTable: "districts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
