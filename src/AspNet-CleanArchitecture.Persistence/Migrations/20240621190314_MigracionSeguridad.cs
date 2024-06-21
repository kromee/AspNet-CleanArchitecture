using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNet_CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionSeguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("0ec123ff-d781-461c-bc40-8f8d275ce02d"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("2d3f6934-eba4-414e-99b5-7c4eae4e741f"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("60896d6c-215d-49f0-91f4-bd1b33e0cf9c"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("81930ad9-f8c2-4357-94c2-2a9871f953d8"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c87464b7-4a05-461a-a764-8fa839f1991c"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("cefc5c27-0dc8-4ec5-8249-f2f0249c0518"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("e077fb98-cb97-44f0-b95a-031a342baa7e"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("e3f7f483-bf41-4889-b677-2061cf358975"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("fca3151f-e4f3-4d56-9860-c7861f9bc10f"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("0902a878-d1cf-4ebe-94c4-e734fe2517c0"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("0d277da6-c499-4be4-a398-9780d0583602"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("41d18f37-d580-4e0f-b4b5-37b17c240e52"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("74bd3331-4ba7-4844-ba49-ccf5dbe8b718"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("8edaf49b-a709-4466-bc89-88c37927ca42"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("92b6f750-2eec-4194-a6b1-e12fe8b7dafc"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("db0bcb11-51c5-4a07-94ec-590fae95c391"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("e2be9ce6-33d1-488c-9e26-7441266cd69e"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("e44c00ec-fe77-4128-b82c-ebdceea3f120"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("f04ad3dc-c799-4554-9770-e737f60dda65"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("24aa5459-8a3b-46de-898e-70d8176f6b90"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    Carrera = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1ebb981-c2ff-4f42-bb38-1bd1b9214f1e", null, "CLIENT", "CLIENT" },
                    { "c9e56335-4681-4fe4-9b9c-d756d89ba8ea", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("15df65da-2e6c-4348-a110-b0ff2f8bdca7"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5450), "Awesome Frozen Gloves" },
                    { new Guid("17d93a36-11d6-4706-a787-e3ebdc3b56ed"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5440), "Awesome Frozen Tuna" },
                    { new Guid("6cc2750d-b2cb-41d7-8e3d-2adaf1ab6054"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5460), "Awesome Cotton Sausages" },
                    { new Guid("76d045fa-0601-425a-a0c0-3af93b7cfb80"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5490), "Refined Granite Fish" },
                    { new Guid("7ae32ea8-9044-4432-b530-3c59aaaf0407"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5200), "Sleek Wooden Cheese" },
                    { new Guid("84297089-73b9-4f33-a960-fcd45df4f58b"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5500), "Licensed Granite Hat" },
                    { new Guid("9150ff64-fccd-4bbe-9f7a-23df14274340"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5550), "Tasty Granite Shoes" },
                    { new Guid("c07660e1-8b87-437b-8e15-29e06a78e9d8"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5420), "Unbranded Rubber Gloves" },
                    { new Guid("fd41d07e-dd10-4fd2-b76d-643a33c57593"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2024, 6, 21, 19, 3, 14, 434, DateTimeKind.Utc).AddTicks(5480), "Handcrafted Concrete Cheese" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("1b1eb072-6bf1-4598-a8b2-5c577bdd9410"), "Leffler", "Direct Solutions Designer", "Ebony" },
                    { new Guid("3774b6cb-7719-485f-8409-90dae5b06b78"), "Klocko", "Human Optimization Officer", "Bradly" },
                    { new Guid("5323e0e0-6abb-4fac-bb3d-b8f9b137e94f"), "Connelly", "Central Directives Specialist", "Jakob" },
                    { new Guid("65df999e-5540-4578-bf0e-c6b28df132b3"), "Dicki", "Corporate Intranet Producer", "Antonio" },
                    { new Guid("6ec7513f-da9d-412a-9b3d-bbbacdc88c07"), "Bernier", "Dynamic Usability Officer", "Laurine" },
                    { new Guid("7c165acc-b68b-4916-99cb-7b970aa28204"), "Lueilwitz", "Product Branding Executive", "Margarett" },
                    { new Guid("add60052-2c26-4c28-a6a9-5a53343779a1"), "Collins", "International Data Specialist", "Gabrielle" },
                    { new Guid("bc84cf33-de64-4cb3-b992-76edef07e7cb"), "Braun", "Internal Optimization Manager", "Albertha" },
                    { new Guid("db74c162-c68c-4fa9-9676-ea23d3caf88b"), "Cormier", "Central Program Executive", "Wilfredo" },
                    { new Guid("e3f4a821-b139-49ea-913f-7e33cb02716c"), "Quitzon", "Forward Creative Agent", "Verla" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("91e68498-fbf8-472a-ad3c-85ec25ac736c"), "Precio 1", 10.0m, 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "CURSO_READ", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 2, "POLICIES", "CURSO_UPDATE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 3, "POLICIES", "CURSO_WRITE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 4, "POLICIES", "CURSO_DELETE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 5, "POLICIES", "INSTRUCTOR_CREATE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 6, "POLICIES", "INSTRUCTOR_READ", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 7, "POLICIES", "INSTRUCTOR_UPDATE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 8, "POLICIES", "COMENTARIO_RED", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 9, "POLICIES", "COMENTARIO_CREATE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 10, "POLICIES", "COMENTARIO_DELETE", "c9e56335-4681-4fe4-9b9c-d756d89ba8ea" },
                    { 11, "POLICIES", "CURSO_READ", "c1ebb981-c2ff-4f42-bb38-1bd1b9214f1e" },
                    { 12, "POLICIES", "INSTRUCTOR_READ", "c1ebb981-c2ff-4f42-bb38-1bd1b9214f1e" },
                    { 13, "POLICIES", "COMENTARIO_RED", "c1ebb981-c2ff-4f42-bb38-1bd1b9214f1e" },
                    { 14, "POLICIES", "COMENTARIO_CREATE", "c1ebb981-c2ff-4f42-bb38-1bd1b9214f1e" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("15df65da-2e6c-4348-a110-b0ff2f8bdca7"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("17d93a36-11d6-4706-a787-e3ebdc3b56ed"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("6cc2750d-b2cb-41d7-8e3d-2adaf1ab6054"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("76d045fa-0601-425a-a0c0-3af93b7cfb80"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("7ae32ea8-9044-4432-b530-3c59aaaf0407"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("84297089-73b9-4f33-a960-fcd45df4f58b"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("9150ff64-fccd-4bbe-9f7a-23df14274340"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c07660e1-8b87-437b-8e15-29e06a78e9d8"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("fd41d07e-dd10-4fd2-b76d-643a33c57593"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("1b1eb072-6bf1-4598-a8b2-5c577bdd9410"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("3774b6cb-7719-485f-8409-90dae5b06b78"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("5323e0e0-6abb-4fac-bb3d-b8f9b137e94f"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("65df999e-5540-4578-bf0e-c6b28df132b3"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("6ec7513f-da9d-412a-9b3d-bbbacdc88c07"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("7c165acc-b68b-4916-99cb-7b970aa28204"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("add60052-2c26-4c28-a6a9-5a53343779a1"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("bc84cf33-de64-4cb3-b992-76edef07e7cb"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("db74c162-c68c-4fa9-9676-ea23d3caf88b"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("e3f4a821-b139-49ea-913f-7e33cb02716c"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("91e68498-fbf8-472a-ad3c-85ec25ac736c"));

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("0ec123ff-d781-461c-bc40-8f8d275ce02d"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4310), "Generic Fresh Pizza" },
                    { new Guid("2d3f6934-eba4-414e-99b5-7c4eae4e741f"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4230), "Refined Concrete Fish" },
                    { new Guid("60896d6c-215d-49f0-91f4-bd1b33e0cf9c"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4210), "Tasty Granite Sausages" },
                    { new Guid("81930ad9-f8c2-4357-94c2-2a9871f953d8"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4290), "Small Cotton Tuna" },
                    { new Guid("c87464b7-4a05-461a-a764-8fa839f1991c"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4250), "Handmade Plastic Towels" },
                    { new Guid("cefc5c27-0dc8-4ec5-8249-f2f0249c0518"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4270), "Unbranded Frozen Fish" },
                    { new Guid("e077fb98-cb97-44f0-b95a-031a342baa7e"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4320), "Sleek Metal Computer" },
                    { new Guid("e3f7f483-bf41-4889-b677-2061cf358975"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4220), "Tasty Frozen Salad" },
                    { new Guid("fca3151f-e4f3-4d56-9860-c7861f9bc10f"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 6, 20, 23, 52, 18, 344, DateTimeKind.Utc).AddTicks(4300), "Gorgeous Metal Gloves" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0902a878-d1cf-4ebe-94c4-e734fe2517c0"), "Towne", "Regional Solutions Agent", "Flavie" },
                    { new Guid("0d277da6-c499-4be4-a398-9780d0583602"), "Herzog", "District Data Representative", "Eino" },
                    { new Guid("41d18f37-d580-4e0f-b4b5-37b17c240e52"), "Borer", "Future Group Facilitator", "Kristian" },
                    { new Guid("74bd3331-4ba7-4844-ba49-ccf5dbe8b718"), "Marvin", "Chief Accounts Director", "Watson" },
                    { new Guid("8edaf49b-a709-4466-bc89-88c37927ca42"), "Windler", "Chief Marketing Executive", "Trisha" },
                    { new Guid("92b6f750-2eec-4194-a6b1-e12fe8b7dafc"), "Hintz", "Customer Quality Strategist", "Destiney" },
                    { new Guid("db0bcb11-51c5-4a07-94ec-590fae95c391"), "Hilll", "Human Communications Architect", "Brandt" },
                    { new Guid("e2be9ce6-33d1-488c-9e26-7441266cd69e"), "Maggio", "National Creative Liaison", "Nella" },
                    { new Guid("e44c00ec-fe77-4128-b82c-ebdceea3f120"), "Halvorson", "Internal Interactions Producer", "Laurie" },
                    { new Guid("f04ad3dc-c799-4554-9770-e737f60dda65"), "O'Kon", "Dynamic Tactics Developer", "Olen" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("24aa5459-8a3b-46de-898e-70d8176f6b90"), "Precio 1", 10.0m, 8.0m });
        }
    }
}
