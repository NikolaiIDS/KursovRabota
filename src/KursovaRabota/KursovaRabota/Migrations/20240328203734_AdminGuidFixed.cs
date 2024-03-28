using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class AdminGuidFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-1676f-44fe-8846-f5099e0e1cc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0778238c-1e1b-4e5d-9ea6-1a01e9264086",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0585026-cac3-40d2-a8c9-0872eaf75e98", "AQAAAAIAAYagAAAAECaoA2QjWg9GvXNiSDk/Y+jFTCsfixEe0MVN9KrIgzJPsB1jaEFZrFlmouHcfENucg==", "1122ed49-4f95-47e5-887c-ce3c018aa050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7594af2-ae37-4217-a1d8-891f590692b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c18892ef-acee-43ae-892b-ab10b2fe1e97", "AQAAAAIAAYagAAAAEGkEbf+L8f0XkYq8JApuU0tuw9GPg+9oW7cEetE4efdL1Q9BmqZk4XqxHSzCJouISw==", "4425bc1b-0abf-42b6-b7df-351c67fdf7e4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Approved", "Class", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "255a2f5d-901c-4966-b091-b5ed871a3c4d", 0, true, null, "839fe063-12fd-4fd2-8b74-aee6224b355f", "admin@email.com", false, "admin", "admin", false, null, "admin@email.com", "admin", "AQAAAAIAAYagAAAAEDdrngLVjxOmpP8cFtp1F/qiKtLuYH+Y711jK7lTMLEA+dXh950aR5yFKhr1alFAUA==", null, false, "6a2eb83d-1ecc-4a68-b590-cfbdcbd74510", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "255a2f5d-901c-4966-b091-b5ed871a3c4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0778238c-1e1b-4e5d-9ea6-1a01e9264086",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c47d4c1b-50ce-45ab-a299-cfb2bd7a9e5e", "AQAAAAIAAYagAAAAEKhxn4BP6OS6h2XaH4ScFrggNCGTvWvdR6CRuG9/WCvUOVbdk03Ru5NwWmscnGJsSA==", "cf888cee-9e1e-4814-8d7f-eb92b1ca9028" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7594af2-ae37-4217-a1d8-891f590692b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3706de3-63a0-4ef4-957a-0f70a7626b56", "AQAAAAIAAYagAAAAENy/+Kwu3rFhNR/DoxvEtkTvBukBhIG1D4HXQtsPNGYWzev5DRRsUmIGGMEehY0nGQ==", "c002c93f-9aa1-4fcf-ae32-a851bbd6f1af" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Approved", "Class", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9de92530-1676f-44fe-8846-f5099e0e1cc3", 0, true, null, "84e44a29-32f6-4ceb-977d-4a79a9bf1b4a", "admin@email.com", false, "admin", "admin", false, null, "admin@email.com", "admin", "AQAAAAIAAYagAAAAEG0XLtSu9BouvT3s+alAo/eqZSTlU6S/bxwlkapYJZFjpPPLZ6GvfiqQGLZtzigRhg==", null, false, "e25a1274-d8f2-420d-8a7f-e0e6c1c4dad6", false, "admin" });
        }
    }
}
