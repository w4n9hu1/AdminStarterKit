using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminStarterKit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserIsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mdm_user_role_mdm_role_RolesId",
                table: "mdm_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_mdm_user_role_mdm_user_UsersId",
                table: "mdm_user_role");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "mdm_user_role",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "mdm_user_role",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_mdm_user_role_UsersId",
                table: "mdm_user_role",
                newName: "IX_mdm_user_role_UserId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "mdm_user",
                type: "TIMESTAMP(3)",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP(3)",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP(3)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "mdm_user",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_mdm_user_role_mdm_role_RoleId",
                table: "mdm_user_role",
                column: "RoleId",
                principalTable: "mdm_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mdm_user_role_mdm_user_UserId",
                table: "mdm_user_role",
                column: "UserId",
                principalTable: "mdm_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mdm_user_role_mdm_role_RoleId",
                table: "mdm_user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_mdm_user_role_mdm_user_UserId",
                table: "mdm_user_role");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "mdm_user");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "mdm_user_role",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "mdm_user_role",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_mdm_user_role_UserId",
                table: "mdm_user_role",
                newName: "IX_mdm_user_role_UsersId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "mdm_user",
                type: "TIMESTAMP(3)",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP(3)",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP(3)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mdm_user_role_mdm_role_RolesId",
                table: "mdm_user_role",
                column: "RolesId",
                principalTable: "mdm_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mdm_user_role_mdm_user_UsersId",
                table: "mdm_user_role",
                column: "UsersId",
                principalTable: "mdm_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
