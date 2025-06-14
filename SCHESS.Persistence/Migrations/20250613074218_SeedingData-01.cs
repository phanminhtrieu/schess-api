using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCHESS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "CreatedUserId", "Description", "ModifiedDate", "ModifiedUserId", "Name", "NormalizedName", "RoleDescription" },
                values: new object[,]
                {
                    { new Guid("69d88ef3-900e-48f1-a45e-1a3bd91eb8d1"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Player", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Player", "PLAYER", "Player" },
                    { new Guid("72895e7d-549d-4d1c-aa24-11e0f05fa93c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Trainer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Trainer", "TRAINER", "Trainer" },
                    { new Guid("851afdd4-0756-4759-b860-625aba4d8024"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Administrator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Admin", "ADMIN", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivateDate", "Avatar", "Bio", "City", "ConcurrencyStamp", "Country", "CreatedDate", "Description", "Dob", "Email", "EmailConfirmed", "FullName", "IsActive", "IsAnonymous", "IsDelete", "LastLogin", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("28879b28-9806-4c3d-9783-88f121e5df97"), 0, null, null, null, null, "9ee36334-f946-4b4d-921a-3eff67d34da8", null, new DateTime(2024, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1955, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "trainer@gmail.com", true, "Nguyen Thanh Tung", true, false, false, null, false, null, new DateTime(2024, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "TRAINER@GMAIL.COM", "TRAINER", "AQAAAAIAAYagAAAAEHvmMIP7QAtfjClTI0AvVTsHfz08IwWRn/lYU4ELXRjyh1ZNavJnWuY0NOSja1rHZA==", null, false, "", false, "trainer" },
                    { new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"), 0, null, null, null, null, "11f6da3e-6e4d-4286-be64-78ab0fe4de75", null, new DateTime(2024, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2004, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Phan Minh Trieu", true, false, false, null, false, null, new DateTime(2024, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEIcKnJ5CX2asNPnXRbBh4bnZESs5qwxtkRDAN/AWjqiGzW7vYMcY1kjt4GXYmU6VDQ==", null, false, "", false, "admin" },
                    { new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"), 0, null, null, null, null, "c58e2295-d4bd-40e1-ae8d-c2d42802c6df", null, new DateTime(2024, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "player@gmail.com", true, "Le Ngoc Hieu", true, false, false, null, false, null, new DateTime(2024, 6, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "PLAYER@GMAIL.COM", "PLAYER", "AQAAAAIAAYagAAAAEFfKcTvD3lK1XP8S0zYUq7OUq81Lgk69qmlSui7n/bL4Ze6LD1aFCu/qSE85Er4g8w==", null, false, "", false, "player" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("72895e7d-549d-4d1c-aa24-11e0f05fa93c"), new Guid("28879b28-9806-4c3d-9783-88f121e5df97") },
                    { new Guid("851afdd4-0756-4759-b860-625aba4d8024"), new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c") },
                    { new Guid("69d88ef3-900e-48f1-a45e-1a3bd91eb8d1"), new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("72895e7d-549d-4d1c-aa24-11e0f05fa93c"), new Guid("28879b28-9806-4c3d-9783-88f121e5df97") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("851afdd4-0756-4759-b860-625aba4d8024"), new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("69d88ef3-900e-48f1-a45e-1a3bd91eb8d1"), new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("69d88ef3-900e-48f1-a45e-1a3bd91eb8d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("72895e7d-549d-4d1c-aa24-11e0f05fa93c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("851afdd4-0756-4759-b860-625aba4d8024"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28879b28-9806-4c3d-9783-88f121e5df97"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"));
        }
    }
}
