using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminStarterKit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "mdm_user",
                type: "TIMESTAMP(3)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(3)",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "mdm_user",
                type: "TIMESTAMP(3)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(3)",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "mdm_user",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP(3)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP(3)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDateTime",
                table: "mdm_user",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP(3)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP(3)");
        }
    }
}
