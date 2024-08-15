using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlogs.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialAuthDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b32db998-a68c-4c86-8a38-8a7906913851",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "206e2045-2ac8-4833-bbd8-d4836e4cebe0", "superadmin@devblog.com", "SUPERADMIN@DEVBLOG.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEE0ByL0IB817bDuaGU0/yr6y+NZM34auxTuPd9invi21BHGuvnfmm+BIxwgN37XSYQ==", "3db9d1c6-f85a-4f5f-ac48-72f09ef68b5a", "superadmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b32db998-a68c-4c86-8a38-8a7906913851",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "74eaaea7-c84e-4429-938f-b82b64872676", "superadmin@bloggie.com", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEEkdCl9KV5ReSERfhNijTdBJpFZES+2okvyvDgVuMkcCgaktjY6FYULJNk3U6JKI0Q==", "36d33d3f-95fe-41dd-9694-8e1c6623fc99", "superadmin@bloggie.com" });
        }
    }
}
