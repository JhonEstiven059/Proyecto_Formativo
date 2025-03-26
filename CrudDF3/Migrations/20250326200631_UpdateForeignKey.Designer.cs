﻿// <auto-generated />
using System;
using CrudDF3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudDF3.Migrations
{
    [DbContext(typeof(CrudDf3Context))]
    [Migration("20250326200631_UpdateForeignKey")]
    partial class UpdateForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudDF3.Models.Habitacione", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHabitacion"));

                    b.Property<int?>("CapacidadHuespedes")
                        .HasColumnType("int");

                    b.Property<string>("CaracteristicasHabitacion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DescripcionHabitacion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("EstadoHabitacion")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TarifaHabitacion")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TipoHabitacion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdHabitacion")
                        .HasName("PK__Habitaci__8BBBF901646793AD");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("CrudDF3.Models.Huespede", b =>
                {
                    b.Property<int>("IdHuesped")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHuesped"));

                    b.Property<string>("ApellidoHuesped")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("CedulaHuesped")
                        .HasColumnType("int");

                    b.Property<string>("CorreoHuesped")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("FechaEntradaHuesped")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaSalidaHuesped")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreHuesped")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdHuesped")
                        .HasName("PK__Huespede__939EC0618E8E6C9A");

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("CrudDF3.Models.PaquetesTuristico", b =>
                {
                    b.Property<int>("IdPaquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaquete"));

                    b.Property<string>("DescripcionPaquete")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DestinoPaquete")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("DisponibilidadPaquete")
                        .HasColumnType("bit");

                    b.Property<bool>("EstadoPaquete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaPaquete")
                        .HasColumnType("datetime");

                    b.Property<string>("NombrePaquete")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("PrecioPaquete")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TipoViajePaquete")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdPaquete")
                        .HasName("PK__Paquetes__DE278F8B44976DDC");

                    b.ToTable("PaquetesTuristicos");
                });

            modelBuilder.Entity("CrudDF3.Models.Permiso", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermiso"));

                    b.Property<string>("DescripcionPermiso")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("EstadoPermiso")
                        .HasColumnType("bit");

                    b.Property<string>("NombrePermiso")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdPermiso")
                        .HasName("PK__Permisos__0D626EC89D1425DC");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("CrudDF3.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<decimal?>("Anticipo")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<bool>("EstadoReserva")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaInicial")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaReserva")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdHuesped")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroPersonas")
                        .HasColumnType("int");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdReserva")
                        .HasName("PK__Reservas__0E49C69DE86ED4F0");

                    b.HasIndex("IdHabitacion");

                    b.HasIndex("IdHuesped");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("CrudDF3.Models.ReservasPaquete", b =>
                {
                    b.Property<int>("IdReservaPaquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservaPaquete"));

                    b.Property<int?>("IdPaquete")
                        .HasColumnType("int");

                    b.Property<int?>("IdReserva")
                        .HasColumnType("int");

                    b.HasKey("IdReservaPaquete")
                        .HasName("PK__Reservas__BF8B0A63C143DE0D");

                    b.HasIndex("IdPaquete");

                    b.HasIndex("IdReserva");

                    b.ToTable("ReservasPaquetes");
                });

            modelBuilder.Entity("CrudDF3.Models.ReservasServicio", b =>
                {
                    b.Property<int>("IdReservaServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservaServicio"));

                    b.Property<int?>("IdReserva")
                        .HasColumnType("int");

                    b.Property<int?>("IdServicio")
                        .HasColumnType("int");

                    b.HasKey("IdReservaServicio")
                        .HasName("PK__Reservas__B3FBC747E65BE0F4");

                    b.HasIndex("IdReserva");

                    b.HasIndex("IdServicio");

                    b.ToTable("ReservasServicios");
                });

            modelBuilder.Entity("CrudDF3.Models.RolPermiso", b =>
                {
                    b.Property<int>("IdRolPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRolPermiso"));

                    b.Property<int?>("IdPermiso")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdRolPermiso")
                        .HasName("PK__Rol_Perm__0CC73B1B717C1734");

                    b.HasIndex("IdPermiso");

                    b.HasIndex("IdRol");

                    b.ToTable("Rol_Permisos", (string)null);
                });

            modelBuilder.Entity("CrudDF3.Models.Role", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("DescripcionRol")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("EstadoRol")
                        .HasColumnType("bit");

                    b.Property<string>("NombreRol")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdRol")
                        .HasName("PK__Roles__2A49584C1BB668CC");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CrudDF3.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"));

                    b.Property<string>("Categoria")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Costo")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<bool>("EstadoServicio")
                        .HasColumnType("bit");

                    b.Property<string>("NombreServicio")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Observacion")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TipoServicio")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdServicio")
                        .HasName("PK__Servicio__2DCCF9A2E3474427");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("CrudDF3.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("ApellidoUsuario")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("CedulaUsuario")
                        .HasColumnType("int");

                    b.Property<string>("ContraseñaUsuario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CorreoUsuario")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EstadoUsuario")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuarios__5B65BF97118D37CE");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CrudDF3.Models.Reserva", b =>
                {
                    b.HasOne("CrudDF3.Models.Habitacione", "IdHabitacionNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("IdHabitacion")
                        .HasConstraintName("FK__Reservas__IdHabi__59FA5E80");

                    b.HasOne("CrudDF3.Models.Huespede", "IdHuespedNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("IdHuesped")
                        .HasConstraintName("FK__Reservas__IdHues__59063A47");

                    b.HasOne("CrudDF3.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Reservas")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Reservas__IdUsua__5812160E");

                    b.Navigation("IdHabitacionNavigation");

                    b.Navigation("IdHuespedNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CrudDF3.Models.ReservasPaquete", b =>
                {
                    b.HasOne("CrudDF3.Models.PaquetesTuristico", "IdPaqueteNavigation")
                        .WithMany("ReservasPaquetes")
                        .HasForeignKey("IdPaquete")
                        .HasConstraintName("FK__ReservasP__IdPaq__656C112C");

                    b.HasOne("CrudDF3.Models.Reserva", "IdReservaNavigation")
                        .WithMany("ReservasPaquetes")
                        .HasForeignKey("IdReserva")
                        .HasConstraintName("FK__ReservasP__IdRes__6477ECF3");

                    b.Navigation("IdPaqueteNavigation");

                    b.Navigation("IdReservaNavigation");
                });

            modelBuilder.Entity("CrudDF3.Models.ReservasServicio", b =>
                {
                    b.HasOne("CrudDF3.Models.Reserva", "IdReservaNavigation")
                        .WithMany("ReservasServicios")
                        .HasForeignKey("IdReserva")
                        .HasConstraintName("FK__ReservasS__IdRes__60A75C0F");

                    b.HasOne("CrudDF3.Models.Servicio", "IdServicioNavigation")
                        .WithMany("ReservasServicios")
                        .HasForeignKey("IdServicio")
                        .HasConstraintName("FK__ReservasS__IdSer__619B8048");

                    b.Navigation("IdReservaNavigation");

                    b.Navigation("IdServicioNavigation");
                });

            modelBuilder.Entity("CrudDF3.Models.RolPermiso", b =>
                {
                    b.HasOne("CrudDF3.Models.Permiso", "IdPermisoNavigation")
                        .WithMany("RolPermisos")
                        .HasForeignKey("IdPermiso")
                        .HasConstraintName("FK__Rol_Permi__IdPer__5DCAEF64");

                    b.HasOne("CrudDF3.Models.Role", "IdRolNavigation")
                        .WithMany("RolPermisos")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("FK__Rol_Permi__IdRol__5CD6CB2B");

                    b.Navigation("IdPermisoNavigation");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("CrudDF3.Models.Usuario", b =>
                {
                    b.HasOne("CrudDF3.Models.Role", "IdRolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Usuarios__IdRol__4D94879B");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("CrudDF3.Models.Habitacione", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CrudDF3.Models.Huespede", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CrudDF3.Models.PaquetesTuristico", b =>
                {
                    b.Navigation("ReservasPaquetes");
                });

            modelBuilder.Entity("CrudDF3.Models.Permiso", b =>
                {
                    b.Navigation("RolPermisos");
                });

            modelBuilder.Entity("CrudDF3.Models.Reserva", b =>
                {
                    b.Navigation("ReservasPaquetes");

                    b.Navigation("ReservasServicios");
                });

            modelBuilder.Entity("CrudDF3.Models.Role", b =>
                {
                    b.Navigation("RolPermisos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CrudDF3.Models.Servicio", b =>
                {
                    b.Navigation("ReservasServicios");
                });

            modelBuilder.Entity("CrudDF3.Models.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
