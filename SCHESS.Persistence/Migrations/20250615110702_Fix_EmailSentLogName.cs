using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHESS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix_EmailSentLogName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailFunctions",
                table: "EmailFunctions");

            migrationBuilder.RenameTable(
                name: "EmailFunctions",
                newName: "EmailSentLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailSentLogs",
                table: "EmailSentLogs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28879b28-9806-4c3d-9783-88f121e5df97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e569edc-3ca8-4971-bcb8-06276dbd9390", "AQAAAAIAAYagAAAAEJ80Eoup5o5r/O8T4gMEbNAZsoSuPamh8i5L++jVoGMSrx+G8JVHZMvgUTU4QdqrPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "465b98b4-c6ec-4cbe-be14-42724aa1b339", "AQAAAAIAAYagAAAAEDKLGQWZMM6ZGkO9yL8xzIV+NvXaYhN857XuGyvkAQymeihJzZ+ZmYAodAcNDLPU4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f2a7b42-a8cf-4450-8aa9-017550ba4df8", "AQAAAAIAAYagAAAAEBYsZ5QDPLlyWuX62zjtx7j2zdtnI2Aj1d+KPtHWLpEd/YNJDA/08+44HiQ81fbzaQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailSentLogs",
                table: "EmailSentLogs");

            migrationBuilder.RenameTable(
                name: "EmailSentLogs",
                newName: "EmailFunctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailFunctions",
                table: "EmailFunctions",
                column: "Id");

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
        }
    }
}
