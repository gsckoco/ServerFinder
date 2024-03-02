using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServerFinder.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    companyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    website = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Company", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Processors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    processorName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pCores = table.Column<int>(type: "int", nullable: false),
                    eCores = table.Column<int>(type: "int", nullable: false),
                    pThreads = table.Column<int>(type: "int", nullable: false),
                    eThreads = table.Column<int>(type: "int", nullable: false),
                    baseFreq = table.Column<int>(type: "int", nullable: false, defaultValue: 1000),
                    brand = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Intel")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Processors", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_Servers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    serverName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ram = table.Column<int>(type: "int", nullable: false),
                    isEcc = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    storage = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    totalStorage = table.Column<int>(type: "int", nullable: false, defaultValue: 1024),
                    connectionSpeed = table.Column<int>(type: "int", nullable: false, defaultValue: 1000),
                    bandwidth = table.Column<int>(type: "int", nullable: false, defaultValue: 1000),
                    isCustomisable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    link = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    company = table.Column<int>(type: "int", nullable: false),
                    processor = table.Column<int>(type: "int", nullable: false),
                    processorCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Servers", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_Servers_tbl_Company",
                        column: x => x.company,
                        principalTable: "tbl_Company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tbl_Servers_tbl_Processors",
                        column: x => x.processor,
                        principalTable: "tbl_Processors",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Servers_company",
                table: "tbl_Servers",
                column: "company");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Servers_processor",
                table: "tbl_Servers",
                column: "processor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Servers");

            migrationBuilder.DropTable(
                name: "tbl_Company");

            migrationBuilder.DropTable(
                name: "tbl_Processors");
        }
    }
}
