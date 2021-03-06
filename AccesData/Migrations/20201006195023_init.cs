﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "varchar(10)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(45)", nullable: true),
                    Email = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(45)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(45)", nullable: true),
                    Autor = table.Column<string>(type: "varchar(45)", nullable: true),
                    Editorial = table.Column<string>(type: "varchar(45)", nullable: true),
                    Edicion = table.Column<string>(type: "varchar(45)", nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(type: "varchar(45)", nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "Date", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alquileres_Cliente_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_Estado",
                        column: x => x.Estado,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perez", "1", "jperez@gmail.com", "Juan" },
                    { 2, "Sosa", "2", "jsosa@gmail.com", "Jose" },
                    { 3, "Ortiz", "3", "gortiz@gmail.com", "Gabriel" },
                    { 4, "Fernandez", "4", "jfernandez@gmail.com", "Javier" }
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alquilado" },
                    { 2, "Reservado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "123", "Agnelli Fernando", "Limitada", "Kapeluz", "vacio", 5, "20 celebres matematicos" },
                    { "234", "Gabriel Garcia Marquez", "Abierta", "Santillana", "vacio", 2, "Cien años de soledad" },
                    { "345", "Johann Wolfgang von Goethe", "Cerrada", "Puerto de palos", "vacio", 1, "Fausto" },
                    { "456", "Miguel de Cervantes", "Limitada", "Kapeluz", "vacio", 2, "Don Quijote De la Mancha" },
                    { "567", "Sofocles", "Abierta", "Santillana", "vacio", 7, "Edipo Rey" },
                    { "678", "Mark Twain", "Cerrada", "Puerto de palos", "vacio", 2, "Las aventuras de Huckleberry Finn" }
                });

            migrationBuilder.InsertData(
                table: "Alquileres",
                columns: new[] { "ID", "Cliente", "Estado", "FechaAlquiler", "FechaDevolucion", "FechaReserva", "ISBN" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Local), null, "123" });

            migrationBuilder.InsertData(
                table: "Alquileres",
                columns: new[] { "ID", "Cliente", "Estado", "FechaAlquiler", "FechaDevolucion", "FechaReserva", "ISBN" },
                values: new object[] { 2, 2, 2, null, null, new DateTime(2020, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), "234" });

            migrationBuilder.InsertData(
                table: "Alquileres",
                columns: new[] { "ID", "Cliente", "Estado", "FechaAlquiler", "FechaDevolucion", "FechaReserva", "ISBN" },
                values: new object[] { 3, 3, 3, null, null, null, "345" });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Cliente",
                table: "Alquileres",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Estado",
                table: "Alquileres",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ISBN",
                table: "Alquileres",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
