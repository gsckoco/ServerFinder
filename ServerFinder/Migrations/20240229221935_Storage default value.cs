using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerFinder.Migrations
{
    /// <inheritdoc />
    public partial class Storagedefaultvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "storage",
                table: "tbl_Servers",
                type: "varchar(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldUnicode: false,
                oldMaxLength: 1024);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "storage",
                table: "tbl_Servers",
                type: "varchar(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1024)",
                oldUnicode: false,
                oldMaxLength: 1024,
                oldDefaultValue: "");
        }
    }
}
