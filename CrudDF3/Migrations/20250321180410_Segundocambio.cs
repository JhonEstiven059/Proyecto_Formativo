using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudDF3.Migrations
{
    /// <inheritdoc />
    public partial class Segundocambio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoHabitacion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CapacidadHuespedes = table.Column<int>(type: "int", nullable: true),
                    EstadoHabitacion = table.Column<bool>(type: "bit", nullable: true),
                    DescripcionHabitacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TarifaHabitacion = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CaracteristicasHabitacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Habitaci__8BBBF901AB9F734A", x => x.IdHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    IdHuesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaHuesped = table.Column<int>(type: "int", nullable: true),
                    NombreHuesped = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ApellidoHuesped = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CorreoHuesped = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaEntradaHuesped = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    FechaSalidaHuesped = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Huespede__939EC061ADE6E85D", x => x.IdHuesped);
                });

            migrationBuilder.CreateTable(
                name: "PaquetesTuristicos",
                columns: table => new
                {
                    IdPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaquete = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DescripcionPaquete = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PrecioPaquete = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DisponibilidadPaquete = table.Column<bool>(type: "bit", nullable: true),
                    FechaPaquete = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DestinoPaquete = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EstadoPaquete = table.Column<bool>(type: "bit", nullable: true),
                    TipoViajePaquete = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paquetes__DE278F8BC5B27D15", x => x.IdPaquete);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePermiso = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DescripcionPermiso = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    EstadoPermiso = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permisos__0D626EC8F5BC11E4", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DescripcionRol = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    EstadoRol = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__2A49584CE39A91C8", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Categoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: true),
                    Observacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EstadoServicio = table.Column<bool>(type: "bit", nullable: true),
                    TipoServicio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__2DCCF9A2CE3B0E14", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "Rol_Permisos",
                columns: table => new
                {
                    IdRolPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    IdPermiso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol_Perm__0CC73B1B42B0CBAB", x => x.IdRolPermiso);
                    table.ForeignKey(
                        name: "FK__Rol_Permi__IdPer__68487DD7",
                        column: x => x.IdPermiso,
                        principalTable: "Permisos",
                        principalColumn: "IdPermiso");
                    table.ForeignKey(
                        name: "FK__Rol_Permi__IdRol__6754599E",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaUsuario = table.Column<int>(type: "int", nullable: true),
                    NombreUsuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ApellidoUsuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CorreoUsuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContraseñaUsuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EstadoUsuario = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__5B65BF97174312CC", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuarios__IdRolU__5070F446",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdHuesped = table.Column<int>(type: "int", nullable: true),
                    IdHabitacion = table.Column<int>(type: "int", nullable: true),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroPersonas = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Anticipo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    EstadoReserva = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__0E49C69D89631E9E", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK__Reservas__IdHabi__628FA481",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion");
                    table.ForeignKey(
                        name: "FK__Reservas__IdHues__619B8048",
                        column: x => x.IdHuesped,
                        principalTable: "Huespedes",
                        principalColumn: "IdHuesped");
                    table.ForeignKey(
                        name: "FK__Reservas__IdUsua__60A75C0F",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "ReservasPaquetes",
                columns: table => new
                {
                    IdReservaPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(type: "int", nullable: true),
                    IdPaquete = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__BF8B0A63F8F0C1E4", x => x.IdReservaPaquete);
                    table.ForeignKey(
                        name: "FK__ReservasP__IdPaq__778AC167",
                        column: x => x.IdPaquete,
                        principalTable: "PaquetesTuristicos",
                        principalColumn: "IdPaquete");
                    table.ForeignKey(
                        name: "FK__ReservasP__IdRes__76969D2E",
                        column: x => x.IdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva");
                });

            migrationBuilder.CreateTable(
                name: "ReservasServicios",
                columns: table => new
                {
                    IdReservaServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(type: "int", nullable: true),
                    IdServicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__B3FBC74775C2BC63", x => x.IdReservaServicio);
                    table.ForeignKey(
                        name: "FK__ReservasS__IdRes__72C60C4A",
                        column: x => x.IdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva");
                    table.ForeignKey(
                        name: "FK__ReservasS__IdSer__73BA3083",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Huespede__0768FF19E7789242",
                table: "Huespedes",
                column: "CedulaHuesped",
                unique: true,
                filter: "[CedulaHuesped] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHuesped",
                table: "Reservas",
                column: "IdHuesped");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasPaquetes_IdPaquete",
                table: "ReservasPaquetes",
                column: "IdPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasPaquetes_IdReserva",
                table: "ReservasPaquetes",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasServicios_IdReserva",
                table: "ReservasServicios",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasServicios_IdServicio",
                table: "ReservasServicios",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Permisos_IdPermiso",
                table: "Rol_Permisos",
                column: "IdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Permisos_IdRol",
                table: "Rol_Permisos",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__36549878C06394A4",
                table: "Usuarios",
                column: "CorreoUsuario",
                unique: true,
                filter: "[CorreoUsuario] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuarios__C0B559BD364A57C5",
                table: "Usuarios",
                column: "CedulaUsuario",
                unique: true,
                filter: "[CedulaUsuario] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasPaquetes");

            migrationBuilder.DropTable(
                name: "ReservasServicios");

            migrationBuilder.DropTable(
                name: "Rol_Permisos");

            migrationBuilder.DropTable(
                name: "PaquetesTuristicos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
