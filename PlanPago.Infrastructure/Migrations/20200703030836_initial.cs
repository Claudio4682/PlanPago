using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanPago.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "PlanesPagos",
                columns: table => new
                {
                    PlanPagoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantCuotas = table.Column<int>(nullable: false),
                    TotalPlan = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false),
                    Interes = table.Column<double>(maxLength: 200, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesPagos", x => x.PlanPagoId);
                    table.ForeignKey(
                        name: "FK_PlanesPagos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    CuotaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImporteCuota = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EstadoCuota = table.Column<int>(nullable: false),
                    PlanPagoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_Cuotas_PlanesPagos_PlanPagoId",
                        column: x => x.PlanPagoId,
                        principalTable: "PlanesPagos",
                        principalColumn: "PlanPagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_PlanPagoId",
                table: "Cuotas",
                column: "PlanPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesPagos_ClienteId",
                table: "PlanesPagos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "PlanesPagos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
