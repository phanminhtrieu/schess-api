using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHESS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailFunction = table.Column<int>(type: "int", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailFunctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSsl = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSettingId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_EmailSettings_EmailSettingId",
                        column: x => x.EmailSettingId,
                        principalTable: "EmailSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28879b28-9806-4c3d-9783-88f121e5df97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b12f284-73fb-44a2-8617-03022ae6777b", "AQAAAAIAAYagAAAAELTSAScI4AGMaO5Dq0q2E4JuVr9BrlCi2fzN5MDByXLqVjUjKkY5o2z6WbukN970EA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f235d47-2328-4b59-89dc-f151d66752af", "AQAAAAIAAYagAAAAEF90TguubM1xSXNY/DRCnSHo3Ut8itwDtvriT08SmFtykG5/6p42iMP9vjvpqQf3iA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "adbee680-53ac-47ec-bd45-239a65a4f268", "AQAAAAIAAYagAAAAEBFFJt5RiCqecyp7zjr5WUVHHjf+Rai3IyApkQXd3AbYC70XcHpl1wtKrRuypOiKpQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailSettingId",
                table: "Emails",
                column: "EmailSettingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailFunctions");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "EmailSettings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28879b28-9806-4c3d-9783-88f121e5df97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c66983ba-640e-4c7e-9795-641b891ab710", "AQAAAAIAAYagAAAAEM4gmjHHJF5jH9vrDOTBbzcF4f4q3iShvwfCvUymzhCHSMpEQXliaLNgWK4lRuekfQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1457628-163c-4c46-a67d-632a97913ee2", "AQAAAAIAAYagAAAAEJ0T6Pg4l+e8xZBCKTY8qE5i27fpMVuhfUb05Tct8Qvb1SKzBqnJrpZlSmd66kSGpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "291a0ecc-7810-459c-841c-e664f1fbb412", "AQAAAAIAAYagAAAAEB/jSmEV01jaHH31qKcpFV+PN/N3z2nYq44JJ8tQjCYooq+2KHveIX4P9qUitSkmfA==" });
        }
    }
}
