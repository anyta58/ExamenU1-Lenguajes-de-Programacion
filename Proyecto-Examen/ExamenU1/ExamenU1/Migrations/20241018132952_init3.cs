using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenU1.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_claims_roles_RoleId",
                schema: "Security",
                table: "roles_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_claims_users_UserId",
                schema: "Security",
                table: "users_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_logins_users_UserId",
                schema: "Security",
                table: "users_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_roles_RoleId",
                schema: "Security",
                table: "users_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_users_UserId",
                schema: "Security",
                table: "users_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_tokens_users_UserId",
                schema: "Security",
                table: "users_tokens");

            migrationBuilder.DropTable(
                name: "requests_permission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "permission_statuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "types_permit",
                schema: "dbo");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_claims_roles_RoleId",
                schema: "Security",
                table: "roles_claims",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_claims_users_UserId",
                schema: "Security",
                table: "users_claims",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_logins_users_UserId",
                schema: "Security",
                table: "users_logins",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_roles_RoleId",
                schema: "Security",
                table: "users_roles",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_users_UserId",
                schema: "Security",
                table: "users_roles",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_tokens_users_UserId",
                schema: "Security",
                table: "users_tokens",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_claims_roles_RoleId",
                schema: "Security",
                table: "roles_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_claims_users_UserId",
                schema: "Security",
                table: "users_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_users_logins_users_UserId",
                schema: "Security",
                table: "users_logins");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_roles_RoleId",
                schema: "Security",
                table: "users_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_users_UserId",
                schema: "Security",
                table: "users_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_tokens_users_UserId",
                schema: "Security",
                table: "users_tokens");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "permission_statuses",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "types_permit",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_permit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requests_permission",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    permission_status = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type_permit_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_requests_permission_permission_statuses_permission_status",
                        column: x => x.permission_status,
                        principalSchema: "dbo",
                        principalTable: "permission_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requests_permission_types_permit_type_permit_id",
                        column: x => x.type_permit_id,
                        principalSchema: "dbo",
                        principalTable: "types_permit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requests_permission_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "Security",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requests_permission_permission_status",
                schema: "dbo",
                table: "requests_permission",
                column: "permission_status");

            migrationBuilder.CreateIndex(
                name: "IX_requests_permission_type_permit_id",
                schema: "dbo",
                table: "requests_permission",
                column: "type_permit_id");

            migrationBuilder.CreateIndex(
                name: "IX_requests_permission_user_id",
                schema: "dbo",
                table: "requests_permission",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_claims_roles_RoleId",
                schema: "Security",
                table: "roles_claims",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_claims_users_UserId",
                schema: "Security",
                table: "users_claims",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_logins_users_UserId",
                schema: "Security",
                table: "users_logins",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_roles_RoleId",
                schema: "Security",
                table: "users_roles",
                column: "RoleId",
                principalSchema: "Security",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_users_UserId",
                schema: "Security",
                table: "users_roles",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_tokens_users_UserId",
                schema: "Security",
                table: "users_tokens",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
