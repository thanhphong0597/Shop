using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAn.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "GenericShoes",
                columns: table => new
                {
                    GenericShoesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericShoes", x => x.GenericShoesID);
                    table.ForeignKey(
                        name: "FK_GenericShoes_Categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificShoes",
                columns: table => new
                {
                    SpecificShoesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    GenericShoesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificShoes", x => x.SpecificShoesID);
                    table.ForeignKey(
                        name: "FK_SpecificShoes_GenericShoes_GenericShoesID",
                        column: x => x.GenericShoesID,
                        principalTable: "GenericShoes",
                        principalColumn: "GenericShoesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoes_Color",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    ShoesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes_Color", x => new { x.ShoesID, x.ColorID });
                    table.ForeignKey(
                        name: "FK_Shoes_Color_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_Color_SpecificShoes_ShoesID",
                        column: x => x.ShoesID,
                        principalTable: "SpecificShoes",
                        principalColumn: "SpecificShoesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoes_Size",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    ShoesID = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_GenericShoes_Category_ID",
                table: "GenericShoes",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Color_ColorID",
                table: "Shoes_Color",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Size_SizeID",
                table: "Shoes_Size",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificShoes_GenericShoesID",
                table: "SpecificShoes",
                column: "GenericShoesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoes_Color");

            migrationBuilder.DropTable(
                name: "Shoes_Size");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "SpecificShoes");

            migrationBuilder.DropTable(
                name: "GenericShoes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
