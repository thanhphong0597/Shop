using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAn.Migrations
{
    public partial class sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Color_Colors_ColorID",
                table: "Shoes_Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Color_GenericShoes_ShoesID",
                table: "Shoes_Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Color_Sizes_SizeID",
                table: "Shoes_Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes_Color",
                table: "Shoes_Color");

            migrationBuilder.RenameTable(
                name: "Shoes_Color",
                newName: "SpecificShoes");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_Color_SizeID",
                table: "SpecificShoes",
                newName: "IX_SpecificShoes_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_Shoes_Color_ColorID",
                table: "SpecificShoes",
                newName: "IX_SpecificShoes_ColorID");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "GenericShoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecificShoes",
                table: "SpecificShoes",
                columns: new[] { "ShoesID", "ColorID", "SizeID" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "Slug",
                value: "giay");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "Slug",
                value: "ao");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "Slug",
                value: "quan");

            migrationBuilder.UpdateData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 1,
                column: "Slug",
                value: "giay_nike");

            migrationBuilder.UpdateData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 2,
                column: "Slug",
                value: "giay_jordan");

            migrationBuilder.UpdateData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 3,
                column: "Slug",
                value: "ao_nike");

            migrationBuilder.UpdateData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 4,
                column: "Slug",
                value: "quan_nike");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificShoes_Colors_ColorID",
                table: "SpecificShoes",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificShoes_GenericShoes_ShoesID",
                table: "SpecificShoes",
                column: "ShoesID",
                principalTable: "GenericShoes",
                principalColumn: "GenericShoesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificShoes_Sizes_SizeID",
                table: "SpecificShoes",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificShoes_Colors_ColorID",
                table: "SpecificShoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificShoes_GenericShoes_ShoesID",
                table: "SpecificShoes");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificShoes_Sizes_SizeID",
                table: "SpecificShoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecificShoes",
                table: "SpecificShoes");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "GenericShoes");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "SpecificShoes",
                newName: "Shoes_Color");

            migrationBuilder.RenameIndex(
                name: "IX_SpecificShoes_SizeID",
                table: "Shoes_Color",
                newName: "IX_Shoes_Color_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_SpecificShoes_ColorID",
                table: "Shoes_Color",
                newName: "IX_Shoes_Color_ColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes_Color",
                table: "Shoes_Color",
                columns: new[] { "ShoesID", "ColorID", "SizeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Color_Colors_ColorID",
                table: "Shoes_Color",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Color_GenericShoes_ShoesID",
                table: "Shoes_Color",
                column: "ShoesID",
                principalTable: "GenericShoes",
                principalColumn: "GenericShoesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Color_Sizes_SizeID",
                table: "Shoes_Color",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
