using Microsoft.EntityFrameworkCore.Migrations;

namespace StereoShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Record Player" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Receiver" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Speakers" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Code", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "rp-sony", "Sony PS-LX310", 289.99000000000001 },
                    { 2, 1, "rp-audio-technica", "Audio-Technica AT-LP60", 229.99000000000001 },
                    { 3, 1, "rp-toshiba", "Toshiba TY-LP200", 299.94999999999999 },
                    { 4, 1, "rp-crosley", "Crosley CR800", 129.99000000000001 },
                    { 5, 1, "rp-victrola", "Victrola VS-990", 99.989999999999995 },
                    { 6, 2, "rec-yamaha", "Yamaha RX-397", 599.99000000000001 },
                    { 7, 2, "rec-sony", "Sony STR-DH190", 249.94999999999999 },
                    { 8, 2, "rec-pioneer", "Pioneer SX10", 349.99000000000001 },
                    { 9, 2, "rec-onkyo", "Onkyo TX8220", 499.99000000000001 },
                    { 10, 2, "rec-insignia", "Insignia NS-STR", 159.99000000000001 },
                    { 11, 3, "sp-klipsch", "Klipsch R-820F", 550.99000000000001 },
                    { 12, 3, "sp-polk", "Polk T50", 299.99000000000001 },
                    { 13, 3, "sp-totem", "Totem Forest", 899.99000000000001 },
                    { 14, 3, "sp-sony", "Sony SS-CS3", 389.99000000000001 },
                    { 15, 3, "sp-jbl", "JBL A170", 409.99000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
