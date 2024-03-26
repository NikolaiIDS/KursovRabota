using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KursovaRabota.Migrations
{
    /// <inheritdoc />
    public partial class tf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("091ab545-db8a-4f99-a90d-eff0459299a9"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("8b17b9a3-9739-49b9-aaf4-75c5f7aef6de"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("9d159406-237e-49a2-b882-a8abfc34ac70"));

            migrationBuilder.DeleteData(
                table: "CompetitionTypes",
                keyColumn: "Id",
                keyValue: new Guid("c1090772-61f3-4d78-951e-cb5543ec4ceb"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("12defb66-0c01-414a-8d94-d2865631bd4a"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("443b7681-f529-4120-a579-69ad8f5707c2"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4f178798-b200-4a74-8bfc-04a5006c9d07"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("dcba1c86-3e9d-4f22-b8c3-5cebfd31137d"));

            migrationBuilder.AddColumn<int>(
                name: "CurrentParticipants",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "530e3922-6f79-4f54-8338-d66741a90a14", "AQAAAAIAAYagAAAAEMcVDEQDMMM9thIFne2u4OK1adGeIBsosSLYbymz8vqb1b2mUq+cAsEj4MYshAUNyA==", "bfb595c7-9600-42d3-945f-85778ac9a1b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eba67d10-b298-40d8-b1ab-7f636ffdcda5", "AQAAAAIAAYagAAAAEEgSA7w/wGvFxC2971jJIgl1/U055Lu5zhkpMMFR2/4YAMfdC81I0AsciWtJcwSfwA==", "b9adf294-6a69-4dd1-b4f6-197117942b32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75bc1729-9800-433d-a1c6-9a94f8249882", "AQAAAAIAAYagAAAAEIZk0zXstzzEDQ4nU5H2MhmkHPIpXq9cJCadwIqT4pp4q+3rTgj4NeYlNAOPaff9FQ==", "6c63ae97-cac5-4798-aac0-5b3d367ccb70" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CurrentParticipants",
                table: "Competitions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f29de16a-2fa6-4998-8152-a710f281f26b", "AQAAAAIAAYagAAAAEIyskt2mYtmAFIpBEpv0zERnQ6lB3uCRFP6OO3RMrXCG1agZmV5laRWoNqDIXb6/fA==", "c775c358-bb71-41f3-97e7-62e21a344304" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29290cff-6a99-4b1e-bf89-380ae5dbf480", "AQAAAAIAAYagAAAAEMSOmJBvk29ug9SkrlsbYvHSokc93+MeN9K4GdjL2jQlVl+TQCiOQDiUJ9dEV2WeEQ==", "a1ce57f6-6250-42df-8b6d-e150a7eef662" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de92530-126f-44fe-8846-f5099e0e1cc5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fab3c037-585a-4264-a5ad-dd4fdc22c388", "AQAAAAIAAYagAAAAEBoHNBq+vDcJdVFd3Q0WjRatBhwN+Z8lmhL0iFDQ0w1bhCP+tlbjj57xRtnOWsOG4A==", "7161697f-f0cf-46c2-8c85-39da01098605" });

            migrationBuilder.InsertData(
                table: "CompetitionTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("091ab545-db8a-4f99-a90d-eff0459299a9"), "Олимпиада" },
                    { new Guid("8b17b9a3-9739-49b9-aaf4-75c5f7aef6de"), "Национален кръг" },
                    { new Guid("9d159406-237e-49a2-b882-a8abfc34ac70"), "Училищно състезание" },
                    { new Guid("c1090772-61f3-4d78-951e-cb5543ec4ceb"), "Областен кръг" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("12defb66-0c01-414a-8d94-d2865631bd4a"), "История" },
                    { new Guid("443b7681-f529-4120-a579-69ad8f5707c2"), "География" },
                    { new Guid("4f178798-b200-4a74-8bfc-04a5006c9d07"), "Математика" },
                    { new Guid("dcba1c86-3e9d-4f22-b8c3-5cebfd31137d"), "Български език" }
                });
        }
    }
}
