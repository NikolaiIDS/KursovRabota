using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class userupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "Approved", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "5769cbe8-db6c-459c-9812-79e5748ac421", "AQAAAAIAAYagAAAAECz8Z2U7WjsWTAmDkU4lvAwH4mlgkaXq3mHs/POd9ZtmxDYCZIWaoyjvUPvIvFG40w==", "3d3c0343-81fa-4d9b-a937-6ed8800fcc3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8615076-33b2-472b-bc3f-c93b8e8d778c", "AQAAAAIAAYagAAAAELlh9J5r1ZMMAPOx3qL5igq7h68FnHSksRFXWlU97cn3zkhLt4OyaqUmcA0IwCxVPQ==", "e54ea66a-ba5e-4bab-8a21-b893974516e5" });
        }
    }
}
