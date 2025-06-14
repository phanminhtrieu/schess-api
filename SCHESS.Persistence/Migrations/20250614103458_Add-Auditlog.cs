using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHESS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccessded = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogins", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogins");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28879b28-9806-4c3d-9783-88f121e5df97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ee36334-f946-4b4d-921a-3eff67d34da8", "AQAAAAIAAYagAAAAEHvmMIP7QAtfjClTI0AvVTsHfz08IwWRn/lYU4ELXRjyh1ZNavJnWuY0NOSja1rHZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11f6da3e-6e4d-4286-be64-78ab0fe4de75", "AQAAAAIAAYagAAAAEIcKnJ5CX2asNPnXRbBh4bnZESs5qwxtkRDAN/AWjqiGzW7vYMcY1kjt4GXYmU6VDQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c58e2295-d4bd-40e1-ae8d-c2d42802c6df", "AQAAAAIAAYagAAAAEFfKcTvD3lK1XP8S0zYUq7OUq81Lgk69qmlSui7n/bL4Ze6LD1aFCu/qSE85Er4g8w==" });
        }
    }
}
