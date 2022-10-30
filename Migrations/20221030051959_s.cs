using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAn.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Color_SpecificShoes_ShoesID",
                table: "Shoes_Color");

            migrationBuilder.DropTable(
                name: "Shoes_Gen");

            migrationBuilder.DropTable(
                name: "Shoes_Size");

            migrationBuilder.DropTable(
                name: "SpecificShoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes_Color",
                table: "Shoes_Color");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "GenericShoes",
                newName: "Images");

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "Shoes_Color",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Shoes_Color",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Shoes_Color",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes_Color",
                table: "Shoes_Color",
                columns: new[] { "ShoesID", "ColorID", "SizeID" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "Name" },
                values: new object[,]
                {
                    { 1, "do" },
                    { 2, "vang" },
                    { 3, "cam" }
                });

            migrationBuilder.InsertData(
                table: "GenericShoes",
                columns: new[] { "GenericShoesID", "Category_ID", "Detail", "Images", "Name" },
                values: new object[,]
                {
                    { 1, 1, "...", "...", "Giay Nike" },
                    { 2, 1, "...", "...", "Giay Jordan" },
                    { 3, 2, "...", "...", "Ao Nike lon" },
                    { 4, 3, "...", "...", "Quan Nike" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "Name" },
                values: new object[,]
                {
                    { 1, "38" },
                    { 2, "39" },
                    { 3, "40" },
                    { 4, "41" }
                });

            migrationBuilder.InsertData(
                table: "Shoes_Color",
                columns: new[] { "ColorID", "ShoesID", "SizeID", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, 20000f, 3 },
                    { 1, 1, 2, 20000f, 2 },
                    { 2, 1, 3, 20000f, 5 },
                    { 1, 2, 2, 20000f, 1 },
                    { 3, 2, 1, 20000f, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Color_SizeID",
                table: "Shoes_Color",
                column: "SizeID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Color_GenericShoes_ShoesID",
                table: "Shoes_Color");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Color_Sizes_SizeID",
                table: "Shoes_Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes_Color",
                table: "Shoes_Color");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_Color_SizeID",
                table: "Shoes_Color");

            migrationBuilder.DeleteData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shoes_Color",
                keyColumns: new[] { "ColorID", "ShoesID", "SizeID" },
                keyColumnTypes: new[] { "int", "int", "int" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Shoes_Color",
                keyColumns: new[] { "ColorID", "ShoesID", "SizeID" },
                keyColumnTypes: new[] { "int", "int", "int" },
                keyValues: new object[] { 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Shoes_Color",
                keyColumns: new[] { "ColorID", "ShoesID", "SizeID" },
                keyColumnTypes: new[] { "int", "int", "int" },
                keyValues: new object[] { 2, 1, 3 });

            migrationBuilder.DeleteData(
                table: "Shoes_Color",
                keyColumns: new[] { "ColorID", "ShoesID", "SizeID" },
                keyColumnTypes: new[] { "int", "int", "int" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "Shoes_Color",
                keyColumns: new[] { "ColorID", "ShoesID", "SizeID" },
                keyColumnTypes: new[] { "int", "int", "int" },
                keyValues: new object[] { 3, 2, 1 });

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GenericShoes",
                keyColumn: "GenericShoesID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "Shoes_Color");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shoes_Color");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Shoes_Color");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "GenericShoes",
                newName: "Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes_Color",
                table: "Shoes_Color",
                columns: new[] { "ShoesID", "ColorID" });

            migrationBuilder.CreateTable(
                name: "SpecificShoes",
                columns: table => new
                {
                    SpecificShoesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificShoes", x => x.SpecificShoesID);
                });

            migrationBuilder.CreateTable(
                name: "Shoes_Gen",
                columns: table => new
                {
                    ShoesID = table.Column<int>(type: "int", nullable: false),
                    GenericShoesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes_Gen", x => new { x.ShoesID, x.GenericShoesID });
                    table.ForeignKey(
                        name: "FK_Shoes_Gen_GenericShoes_GenericShoesID",
                        column: x => x.GenericShoesID,
                        principalTable: "GenericShoes",
                        principalColumn: "GenericShoesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_Gen_SpecificShoes_ShoesID",
                        column: x => x.ShoesID,
                        principalTable: "SpecificShoes",
                        principalColumn: "SpecificShoesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoes_Size",
                columns: table => new
                {
                    ShoesID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes_Size", x => new { x.ShoesID, x.SizeID });
                    table.ForeignKey(
                        name: "FK_Shoes_Size_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_Size_SpecificShoes_ShoesID",
                        column: x => x.ShoesID,
                        principalTable: "SpecificShoes",
                        principalColumn: "SpecificShoesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Gen_GenericShoesID",
                table: "Shoes_Gen",
                column: "GenericShoesID");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Size_SizeID",
                table: "Shoes_Size",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Color_SpecificShoes_ShoesID",
                table: "Shoes_Color",
                column: "ShoesID",
                principalTable: "SpecificShoes",
                principalColumn: "SpecificShoesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
