using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class dateOfCnduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfConduct",
                table: "Competitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfConduct",
                table: "Competitions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0778238c-1e1b-4e5d-9ea6-1a01e9264086",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0585026-cac3-40d2-a8c9-0872eaf75e98", "AQAAAAIAAYagAAAAECaoA2QjWg9GvXNiSDk/Y+jFTCsfixEe0MVN9KrIgzJPsB1jaEFZrFlmouHcfENucg==", "1122ed49-4f95-47e5-887c-ce3c018aa050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "255a2f5d-901c-4966-b091-b5ed871a3c4d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "839fe063-12fd-4fd2-8b74-aee6224b355f", "AQAAAAIAAYagAAAAEDdrngLVjxOmpP8cFtp1F/qiKtLuYH+Y711jK7lTMLEA+dXh950aR5yFKhr1alFAUA==", "6a2eb83d-1ecc-4a68-b590-cfbdcbd74510" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7594af2-ae37-4217-a1d8-891f590692b3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c18892ef-acee-43ae-892b-ab10b2fe1e97", "AQAAAAIAAYagAAAAEGkEbf+L8f0XkYq8JApuU0tuw9GPg+9oW7cEetE4efdL1Q9BmqZk4XqxHSzCJouISw==", "4425bc1b-0abf-42b6-b7df-351c67fdf7e4" });
        }
    }
}
