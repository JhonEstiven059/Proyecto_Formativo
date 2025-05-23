﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudDF3.Models;

public partial class CrudDf3Context : DbContext
{
    public CrudDf3Context()
    {
    }

    public CrudDf3Context(DbContextOptions<CrudDf3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Huespede> Huespedes { get; set; }

    public virtual DbSet<PaquetesTuristico> PaquetesTuristicos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservasPaquete> ReservasPaquetes { get; set; }

    public virtual DbSet<ReservasServicio> ReservasServicios { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-NHQ1PKN2\\SQLEXPRESS01; database=CrudDF3; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF901646793AD");

            entity.Property(e => e.CaracteristicasHabitacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionHabitacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TarifaHabitacion).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoHabitacion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Huespede>(entity =>
        {
            entity.HasKey(e => e.IdHuesped).HasName("PK__Huespede__939EC0618E8E6C9A");

            entity.Property(e => e.ApellidoHuesped)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoHuesped)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntradaHuesped).HasColumnType("datetime");
            entity.Property(e => e.FechaSalidaHuesped).HasColumnType("datetime");
            entity.Property(e => e.NombreHuesped)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaquetesTuristico>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PK__Paquetes__DE278F8B44976DDC");

            entity.Property(e => e.DescripcionPaquete)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DestinoPaquete)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaPaquete).HasColumnType("datetime");
            entity.Property(e => e.NombrePaquete)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioPaquete).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoViajePaquete)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC89D1425DC");

            entity.Property(e => e.DescripcionPermiso)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__0E49C69DE86ED4F0");

            entity.Property(e => e.Anticipo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime");
            entity.Property(e => e.FechaReserva).HasColumnType("datetime");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Reservas__IdHabi__59FA5E80");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHuesped)
                .HasConstraintName("FK__Reservas__IdHues__59063A47");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reservas__IdUsua__5812160E");
        });

        modelBuilder.Entity<ReservasPaquete>(entity =>
        {
            entity.HasKey(e => e.IdReservaPaquete).HasName("PK__Reservas__BF8B0A63C143DE0D");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.ReservasPaquetes)
                .HasForeignKey(d => d.IdPaquete)
                .HasConstraintName("FK__ReservasP__IdPaq__656C112C");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservasPaquetes)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__ReservasP__IdRes__6477ECF3");
        });

        modelBuilder.Entity<ReservasServicio>(entity =>
        {
            entity.HasKey(e => e.IdReservaServicio).HasName("PK__Reservas__B3FBC747E65BE0F4");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservasServicios)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__ReservasS__IdRes__60A75C0F");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ReservasServicios)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__ReservasS__IdSer__619B8048");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.IdRolPermiso).HasName("PK__Rol_Perm__0CC73B1B717C1734");

            entity.ToTable("Rol_Permisos");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .HasConstraintName("FK__Rol_Permi__IdPer__5DCAEF64");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Rol_Permi__IdRol__5CD6CB2B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C1BB668CC");

            entity.Property(e => e.DescripcionRol)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__2DCCF9A2E3474427");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97118D37CE");

            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContraseñaUsuario)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.SetNull) // PERMITE QUE IdRol SE PONGA EN NULL CUANDO SE ELIMINE UN ROL
                .HasConstraintName("FK__Usuarios__IdRol__4D94879B");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
