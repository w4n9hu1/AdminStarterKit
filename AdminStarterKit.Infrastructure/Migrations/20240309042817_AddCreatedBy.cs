using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminStarterKit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "mdm_user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "mdm_role",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "mdm_user");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "mdm_role");
        }
    }
}
