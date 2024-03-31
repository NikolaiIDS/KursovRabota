using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class wtf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0778238c-1e1b-4e5d-9ea6-1a01e9264086",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce2e68c8-b7de-4c21-b34e-5068d2e77027", "AQAAAAIAAYagAAAAEDSuEOKXog6z4lYWK9vk6U2Z1FXGCP9r0u5HkwJhis5XSIjm/njx3VrT5aI+dSxgMA==", "a50f515a-fcc9-42de-ae6f-b6bed7be553f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "255a2f5d-901c-4966-b091-b5ed871a3c4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b87caf61-6054-4f45-b226-5401e0fd528d", "AQAAAAIAAYagAAAAECHRBCaYQ6YfjaPZcswG2y7xH6aTrXIYMWui266alHWGb27vZ4h3u98WIFOql0iqcg==", "c3b65539-0308-4966-b03e-89ef3ad45d08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7594af2-ae37-4217-a1d8-891f590692b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1da4efe-4583-4d28-9ce4-203ae5fb8907", "AQAAAAIAAYagAAAAEAEwJWudLBgSzdjGnhbtabAy/xQDDjFjXxjRGit15WF9p2wccVykiqOwJ6ApaEcFpQ==", "d1ab8656-1d2e-40d7-82fc-688ff4554ed3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0778238c-1e1b-4e5d-9ea6-1a01e9264086",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5965000-f49a-4a74-aedf-3c3d99f53f9a", "AQAAAAIAAYagAAAAEPGLJAE0SIJOhNre0QAZ/6oKoq010Ubk3+h9Ls/Og8mAG425k8UJqspj3gXAIxBDRg==", "d3291787-b404-441b-8e08-7fe13de5d19b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "255a2f5d-901c-4966-b091-b5ed871a3c4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d097b85f-faea-4ea1-8e6b-5b5b23b60cfc", "AQAAAAIAAYagAAAAEDqRQTmLlpORSNgTWXus3ItkI+B1QF++D7jQmaFz0i38p12imC+aA04nHpXW8xboYg==", "435abd3a-0f2b-4878-8dbe-8f2e5bbb7020" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7594af2-ae37-4217-a1d8-891f590692b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65b388f7-603b-41d6-873e-e6a2e5e6a131", "AQAAAAIAAYagAAAAEHG3KhhEB5bbVdcFZALIT7KVwf8nNFFniuZ5rW2pA+H8v6vntuXWJta7/wdMOv8jTQ==", "8e734066-7c7c-4e9f-9753-6a0fa31d06b9" });
        }
    }
}
