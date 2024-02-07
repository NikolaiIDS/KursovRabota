using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class seeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "Approved", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "0aa229f3-0b11-4c81-bd63-f77b1756f5fb", "AQAAAAIAAYagAAAAEGP4Ehc9PN/sdLqei1nrr5jC3s+0CSNSjoSYBmSKvXPtNl+aQ3YYRXEy3Z8+jl3WsQ==", "2aafadc4-b301-41cc-b7ee-16ce79ba046e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "Approved", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "5769cbe8-db6c-459c-9812-79e5748ac421", "AQAAAAIAAYagAAAAECz8Z2U7WjsWTAmDkU4lvAwH4mlgkaXq3mHs/POd9ZtmxDYCZIWaoyjvUPvIvFG40w==", "3d3c0343-81fa-4d9b-a937-6ed8800fcc3b" });
        }
    }
}
