using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class fixedGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc5");

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("21b27fb3-6e6d-43d1-bb66-3ca8950434dd"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("7d3c2ad7-3445-4f66-afa5-ef1401835de9"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b25c8318-c7c4-439f-89bc-4d0f47eba98e"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("cdce9edf-186d-4c3c-b0e2-f1ccf5cab754"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("1b1624b7-47e1-41d2-8065-eb5a7623b131"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("30ec378d-0834-4452-85c6-54f26f3c1577"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("6cba3599-77a8-45d7-b14d-5a1c28b8843f"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("b4c8b14e-b6db-46d7-80e8-81b17516303d"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Approved", "Class", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0778238c-1e1b-4e5d-9ea6-1a01e9264086", 0, true, null, "c47d4c1b-50ce-45ab-a299-cfb2bd7a9e5e", "student@email.com", false, "student", "student", false, null, "student@email.com", "student", "AQAAAAIAAYagAAAAEKhxn4BP6OS6h2XaH4ScFrggNCGTvWvdR6CRuG9/WCvUOVbdk03Ru5NwWmscnGJsSA==", null, false, "cf888cee-9e1e-4814-8d7f-eb92b1ca9028", false, "student" },
                    { "9de92530-1676f-44fe-8846-f5099e0e1cc3", 0, true, null, "84e44a29-32f6-4ceb-977d-4a79a9bf1b4a", "admin@email.com", false, "admin", "admin", false, null, "admin@email.com", "admin", "AQAAAAIAAYagAAAAEG0XLtSu9BouvT3s+alAo/eqZSTlU6S/bxwlkapYJZFjpPPLZ6GvfiqQGLZtzigRhg==", null, false, "e25a1274-d8f2-420d-8a7f-e0e6c1c4dad6", false, "admin" },
                    { "a7594af2-ae37-4217-a1d8-891f590692b3", 0, true, null, "b3706de3-63a0-4ef4-957a-0f70a7626b56", "teacher@email.com", false, "teacher", "teacher", false, null, "teacher@email.com", "teacher", "AQAAAAIAAYagAAAAENy/+Kwu3rFhNR/DoxvEtkTvBukBhIG1D4HXQtsPNGYWzev5DRRsUmIGGMEehY0nGQ==", null, false, "c002c93f-9aa1-4fcf-ae32-a851bbd6f1af", false, "teacher" }
                });

            migrationBuilder.InsertData(
                table: "CompetitionTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("2374a7b3-41ad-4d18-9f2b-f291ea349122"), "Олимпиада" },
                    { new Guid("714b850f-3f77-4739-8c27-0638c6ba5ec4"), "Областен кръг" },
                    { new Guid("9bd1d73d-9cc4-4786-af65-41de7aef86e1"), "Училищно състезание" },
                    { new Guid("dc513c92-13a2-431b-bc36-5a1cba5bd9dc"), "Национален кръг" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("349c02ab-2ffd-4612-b072-a9424289631b"), "История" },
                    { new Guid("5c07e541-15f7-4d78-be88-d832b22a6a16"), "География" },
                    { new Guid("8c7cce8b-25dc-4b62-8181-8e9a25d08075"), "Математика" },
                    { new Guid("f2d0f16e-476f-4796-9b8b-eb2a064c4aa8"), "Български език" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0778238c-1e1b-4e5d-9ea6-1a01e9264086");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-1676f-44fe-8846-f5099e0e1cc3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7594af2-ae37-4217-a1d8-891f590692b3");

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("2374a7b3-41ad-4d18-9f2b-f291ea349122"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("714b850f-3f77-4739-8c27-0638c6ba5ec4"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("9bd1d73d-9cc4-4786-af65-41de7aef86e1"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc513c92-13a2-431b-bc36-5a1cba5bd9dc"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("349c02ab-2ffd-4612-b072-a9424289631b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("5c07e541-15f7-4d78-be88-d832b22a6a16"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8c7cce8b-25dc-4b62-8181-8e9a25d08075"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f2d0f16e-476f-4796-9b8b-eb2a064c4aa8"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Approved", "Class", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9de92530-126f-44fe-8846-f5099e0e1cc3", 0, true, null, "530e3922-6f79-4f54-8338-d66741a90a14", "admin@email.com", false, "admin", "admin", false, null, "admin@email.com", "admin", "AQAAAAIAAYagAAAAEMcVDEQDMMM9thIFne2u4OK1adGeIBsosSLYbymz8vqb1b2mUq+cAsEj4MYshAUNyA==", null, false, "bfb595c7-9600-42d3-945f-85778ac9a1b6", false, "admin" },
                    { "9de92530-126f-44fe-8846-f5099e0e1cc4", 0, true, null, "eba67d10-b298-40d8-b1ab-7f636ffdcda5", "teacher@email.com", false, "teacher", "teacher", false, null, "teacher@email.com", "teacher", "AQAAAAIAAYagAAAAEEgSA7w/wGvFxC2971jJIgl1/U055Lu5zhkpMMFR2/4YAMfdC81I0AsciWtJcwSfwA==", null, false, "b9adf294-6a69-4dd1-b4f6-197117942b32", false, "teacher" },
                    { "9de92530-126f-44fe-8846-f5099e0e1cc5", 0, true, null, "75bc1729-9800-433d-a1c6-9a94f8249882", "student@email.com", false, "student", "student", false, null, "student@email.com", "student", "AQAAAAIAAYagAAAAEIZk0zXstzzEDQ4nU5H2MhmkHPIpXq9cJCadwIqT4pp4q+3rTgj4NeYlNAOPaff9FQ==", null, false, "6c63ae97-cac5-4798-aac0-5b3d367ccb70", false, "student" }
                });

            migrationBuilder.InsertData(
                table: "CompetitionTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("21b27fb3-6e6d-43d1-bb66-3ca8950434dd"), "Училищно състезание" },
                    { new Guid("7d3c2ad7-3445-4f66-afa5-ef1401835de9"), "Олимпиада" },
                    { new Guid("b25c8318-c7c4-439f-89bc-4d0f47eba98e"), "Областен кръг" },
                    { new Guid("cdce9edf-186d-4c3c-b0e2-f1ccf5cab754"), "Национален кръг" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("1b1624b7-47e1-41d2-8065-eb5a7623b131"), "История" },
                    { new Guid("30ec378d-0834-4452-85c6-54f26f3c1577"), "Български език" },
                    { new Guid("6cba3599-77a8-45d7-b14d-5a1c28b8843f"), "География" },
                    { new Guid("b4c8b14e-b6db-46d7-80e8-81b17516303d"), "Математика" }
                });
        }
    }
}
