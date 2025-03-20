using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server= LAPTOP-NHQ1PKN2\\SQLEXPRESS01; database=CrudDF3; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF901AB9F734A");

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
            entity.HasKey(e => e.IdHuesped).HasName("PK__Huespede__939EC061ADE6E85D");

            entity.HasIndex(e => e.CedulaHuesped, "UQ__Huespede__0768FF19E7789242").IsUnique();

            entity.Property(e => e.ApellidoHuesped)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoHuesped)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntradaHuesped).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FechaSalidaHuesped).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NombreHuesped)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaquetesTuristico>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PK__Paquetes__DE278F8BC5B27D15");

            entity.Property(e => e.DescripcionPaquete)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DestinoPaquete)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaPaquete).HasDefaultValueSql("(getdate())");
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
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC8F5BC11E4");

            entity.Property(e => e.DescripcionPermiso)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__0E49C69D89631E9E");

            entity.HasIndex(e => e.CodigoReserva, "UQ__Reservas__F4D3D9826FE9164A").IsUnique();

            entity.Property(e => e.Anticipo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CodigoReserva)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaReserva).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__IdHabi__628FA481");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHuesped)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__IdHues__619B8048");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__IdUsua__60A75C0F");
        });

        modelBuilder.Entity<ReservasPaquete>(entity =>
        {
            entity.HasKey(e => e.IdReservaPaquete).HasName("PK__Reservas__BF8B0A63F8F0C1E4");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.ReservasPaquetes)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservasP__IdPaq__778AC167");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservasPaquetes)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservasP__IdRes__76969D2E");
        });

        modelBuilder.Entity<ReservasServicio>(entity =>
        {
            entity.HasKey(e => e.IdReservaServicio).HasName("PK__Reservas__B3FBC74775C2BC63");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservasServicios)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservasS__IdRes__72C60C4A");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ReservasServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservasS__IdSer__73BA3083");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.IdRolPermiso).HasName("PK__Rol_Perm__0CC73B1B42B0CBAB");

            entity.ToTable("Rol_Permisos");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rol_Permi__IdPer__68487DD7");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rol_Permi__IdRol__6754599E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584CE39A91C8");

            entity.Property(e => e.DescripcionRol)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__2DCCF9A2CE3B0E14");

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
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97174312CC");

            entity.HasIndex(e => e.CorreoUsuario, "UQ__Usuarios__36549878C06394A4").IsUnique();

            entity.HasIndex(e => e.CedulaUsuario, "UQ__Usuarios__C0B559BD364A57C5").IsUnique();

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
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolUsuariosNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRolUsuarios)
                .HasConstraintName("FK__Usuarios__IdRolU__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
