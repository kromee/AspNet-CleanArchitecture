using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNet_CleanArchitecture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instructores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Grado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "precios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    PrecioActual = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Alumno = table.Column<string>(type: "TEXT", nullable: true),
                    Puntaje = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calificaciones_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "curso_instructores",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_instructores", x => new { x.InstructorId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_curso_instructores_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_curso_instructores_instructores_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos_precio",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrecioId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos_precio", x => new { x.PrecioId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_cursos_precio_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_precio_precios_PrecioId",
                        column: x => x.PrecioId,
                        principalTable: "precios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_CursoId",
                table: "calificaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_curso_instructores_CursoId",
                table: "curso_instructores",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_precio_CursoId",
                table: "cursos_precio",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_CursoId",
                table: "imagenes",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "curso_instructores");

            migrationBuilder.DropTable(
                name: "cursos_precio");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "instructores");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
