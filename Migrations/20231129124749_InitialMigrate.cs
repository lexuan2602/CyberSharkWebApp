using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TEST_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    brand_image = table.Column<string>(type: "longtext", nullable: false),
                    date_deleted = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_modied = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Category_Image = table.Column<string>(type: "longtext", nullable: false),
                    date_deleted = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_modied = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Ten = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Mat_khau = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    So_dien_thoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Hinhanh = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    cost_price = table.Column<double>(type: "double", nullable: true),
                    sale_price = table.Column<double>(type: "double", nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    product_images = table.Column<string>(type: "longtext", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    brand_id = table.Column<int>(type: "int", nullable: false),
                    date_deleted = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    date_modied = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_brand_id",
                        column: x => x.brand_id,
                        principalTable: "Brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Product_brand_id",
                table: "Product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
