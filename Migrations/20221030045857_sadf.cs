using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAn.Migrations
{
    public partial class sadf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificShoes_GenericShoes_GenericShoesID",
                table: "SpecificShoes");

            migrationBuilder.DropIndex(
                name: "IX_SpecificShoes_GenericShoesID",
                table: "SpecificShoes");

            migrationBuilder.DropColumn(
                name: "GenericShoesID",
                table: "SpecificShoes");

            migrationBuilder.CreateTable(
                name: "Shoes_Gen",
                columns: table => new
                {
                    GenericShoesID = table.Column<int>(type: "int", nullable: false),
                    ShoesID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_Gen_GenericShoesID",
                table: "Shoes_Gen",
                column: "GenericShoesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shoes_Gen");

            migrationBuilder.AddColumn<int>(
                name: "GenericShoesID",
                table: "SpecificShoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecificShoes_GenericShoesID",
                table: "SpecificShoes",
                column: "GenericShoesID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificShoes_GenericShoes_GenericShoesID",
                table: "SpecificShoes",
                column: "GenericShoesID",
                principalTable: "GenericShoes",
                principalColumn: "GenericShoesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
