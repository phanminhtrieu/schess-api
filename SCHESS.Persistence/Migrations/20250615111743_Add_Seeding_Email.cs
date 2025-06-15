using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHESS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Seeding_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28879b28-9806-4c3d-9783-88f121e5df97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "797d24b3-961d-49e4-84d3-80662b194fa7", "AQAAAAIAAYagAAAAEKRJpLq+vTJWJOC7r3xlZBQHziGRpW/HOmTl9IbtIzXK0gPrpdT6xCvdGMGsTx0vgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d348c254-4115-45c7-a56b-c0361db738b8", "AQAAAAIAAYagAAAAEGTfQoo8p+BDdKpNj8pg6LM3sNN4zmPAaN2CAYKzlTLbtljGfIwNcW0vjz482d6DbA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("af6c5318-d37a-4359-beb6-19f0ce1b6e38"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "516e12ff-a333-4b25-bc2b-aff0f17493ac", "AQAAAAIAAYagAAAAEKHkxpnlwJFtBwIzJWBkBLxQN2DkOlcoTU1ysG0pu/L8aB6NwKO3hanw/hlwrZFZ2g==" });

            migrationBuilder.InsertData(
                table: "EmailSettings",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DisplayName", "FromEmail", "HostName", "Ip", "IsActive", "IsSsl", "ModifiedDate", "ModifiedUserId", "Password", "Port", "Username" },
                values: new object[] { 1, new DateTime(2025, 6, 15, 11, 17, 42, 671, DateTimeKind.Utc).AddTicks(6803), new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"), null, null, null, null, true, true, new DateTime(2025, 6, 15, 11, 17, 42, 671, DateTimeKind.Utc).AddTicks(6807), new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"), null, null, null });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Body", "Code", "CreatedDate", "CreatedUserId", "EmailSettingId", "Function", "ModifiedDate", "ModifiedUserId", "Subject", "Title" },
                values: new object[] { 1, "<figure class=\"table\">\r\n  <table>\r\n    <tbody>\r\n      <!-- Phần nội dung chính -->\r\n      <tr>\r\n        <td>\r\n          <p style=\"margin-left:20px;\">\r\n            <strong>Chào mừng đến với SCHESS!</strong>\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            Để kích hoạt tài khoản, vui lòng nhấn nút bên dưới để xác thực địa chỉ email.\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            <a href=\"{{confirmationLink}}\">Kích hoạt tài khoản</a>\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            Trong trường hợp nút kích hoạt ở trên không hoạt động, hãy sao chép và dán đường link này vào trình duyệt của bạn:\r\n          </p>\r\n          <p style=\"margin-left:20px;\">\r\n            <a href=\"{{confirmationLink}}\">{{confirmationLink}}</a>\r\n          </p>\r\n        </td>\r\n      </tr>\r\n    </tbody>\r\n  </table>\r\n</figure>", "SEND_EMAIL_CONFIRMATION", new DateTime(2025, 6, 15, 11, 17, 42, 671, DateTimeKind.Utc).AddTicks(6867), new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"), 1, 1, new DateTime(2025, 6, 15, 11, 17, 42, 671, DateTimeKind.Utc).AddTicks(6867), new Guid("680b988b-4c45-4f74-9972-c9d3897aa93c"), "Email Confirmation", "Email Confirmation" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmailSettings",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
