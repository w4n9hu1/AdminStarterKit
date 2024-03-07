using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminStarterKit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "mdm_role",
                type: "TIMESTAMP(3)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(3)",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "now()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "mdm_role",
                type: "datetime",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(3)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP(3)");
        }
    }
}
