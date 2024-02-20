using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class blop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02416159-acb2-4f4d-a58c-f67bd1bde343");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9647886c-0b29-4e53-a29c-6e261b5f0a82");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6160e632-043f-4e6b-aba3-5e3d4d32d934", "9de92530-126f-44fe-8846-f5099e0e1cc3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6160e632-043f-4e6b-aba3-5e3d4d32d934");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d016052-88da-4f1a-9c94-7bd750a4ce5e", "AQAAAAIAAYagAAAAECjauQ1z7IcIZfXV2vbDaruxFC1s5bvCUX817PxFi5g+MZonkeVJparwiVepV0Jkvw==", "73eb76e8-a730-4d33-ab5c-d29d912f6bcb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02416159-acb2-4f4d-a58c-f67bd1bde343", "79020e06-a9a2-4b07-8bad-e87e196496fb", "Teacher", "TEACHER" },
                    { "6160e632-043f-4e6b-aba3-5e3d4d32d934", "ae5ae6c2-548c-401d-b867-3edc9cad611c", "Admin", "ADMIN" },
                    { "9647886c-0b29-4e53-a29c-6e261b5f0a82", "56fdaef0-c138-42eb-93f1-5756ad7f647f", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0aa229f3-0b11-4c81-bd63-f77b1756f5fb", "AQAAAAIAAYagAAAAEGP4Ehc9PN/sdLqei1nrr5jC3s+0CSNSjoSYBmSKvXPtNl+aQ3YYRXEy3Z8+jl3WsQ==", "2aafadc4-b301-41cc-b7ee-16ce79ba046e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6160e632-043f-4e6b-aba3-5e3d4d32d934", "9de92530-126f-44fe-8846-f5099e0e1cc3" });
        }
    }
}
