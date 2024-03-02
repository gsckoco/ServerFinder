using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerFinder.Migrations
{
    /// <inheritdoc />
    public partial class ExchangeRates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price_gbp",
                table: "tbl_Servers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "tbl_Rates",
                columns: table => new
                {
                    currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    rate = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Rates", x => x.currency);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Rates");

            migrationBuilder.DropColumn(
                name: "price_gbp",
                table: "tbl_Servers");
        }
    }
}
