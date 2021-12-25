using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.Tools;
#nullable disable

namespace Prestamos.Infrastructure.DbContexts
{
    public partial class PrestamosDBContext : DbContext
    {
        public PrestamosDBContext()
        {
        }

        public PrestamosDBContext(DbContextOptions<PrestamosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetallePrestamo> DetallePrestamos { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Estatus> Estatuses { get; set; }
        public virtual DbSet<EstatusCrediticio> EstatusCrediticios { get; set; }
        public virtual DbSet<EstatusPrestamo> EstatusPrestamos { get; set; }
        public virtual DbSet<PeriodoPago> PeriodoPagos { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasIndex(e => e.Cedula).IsUnique();

                entity.Property(e => e.FechaActualizado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreado).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__Clientes__IdDire__398D8EEE");

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEstatus)
                    .HasConstraintName("FK__Clientes__IdEsta__3A81B327");

                entity.HasOne(d => d.EstatusCrediticio)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEstatusCrediticio)
                    .HasConstraintName("FK__Clientes__IdEsta__3B75D760");
            });

            modelBuilder.Entity<DetallePrestamo>(entity =>
            {
                entity.Property(e => e.CapitalAmortizado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CapitalPendiente).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CuotaPagar).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.InteresPagar).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pagado).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.EstatusPrestamo)
                    .WithMany(p => p.DetallePrestamos)
                    .HasForeignKey(d => d.IdEstatusPrestamo);

                entity.HasOne(d => d.Prestamo)
                    .WithMany(p => p.DetallePrestamos)
                    .HasForeignKey(d => d.IdPrestamo);
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("Direccion");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreado).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rnc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RNC");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdAdministrador)
                    .HasConstraintName("FK__Empresa__IdAdmin__36B12243");

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__Empresa__IdDirec__35BCFE0A");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.ToTable("Estatus");

                entity.Property(e => e.EstatusClientes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstatusCrediticio>(entity =>
            {
                entity.ToTable("EstatusCrediticio");

                entity.Property(e => e.EstatusCrediticios)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstatusPrestamo>(entity =>
            {
                entity.Property(e => e.EstatusPrestamos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodoPago>(entity =>
            {
                entity.ToTable("PeriodoPago");

                entity.Property(e => e.PeriodoDePagos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

    

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Capital).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FechaCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaCulminacion).HasColumnType("datetime");

                entity.Property(e => e.Interes).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.EstatusPrestamo)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdEstatusPrestamo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.PeriodoPago)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdPeriodoPago)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.UsuarioUtorizador)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdUsuarioUtorizador)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Cliente)
                   .WithMany(p => p.Prestamos)
                   .HasForeignKey(d => d.IdCliente)
                   .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizado).HasColumnType("datetime");

                entity.Property(e => e.FechaCreado).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK__Usuarios__IdDire__30F848ED");

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstatus)
                    .HasConstraintName("FK__Usuarios__IdEsta__31EC6D26");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuarios__IdRol__32E0915F");
            });

           

            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Role>().HasData(DefaultData.GetDefaultDataRoles());
            modelBuilder.Entity<Estatus>().HasData(DefaultData.GetDefaultDataEstatus());
            modelBuilder.Entity<EstatusCrediticio>().HasData(DefaultData.GetDefaultDataEstatusCrediticio());
            modelBuilder.Entity<EstatusPrestamo>().HasData(DefaultData.GetDefaultDataEstatusPrestamo());
            modelBuilder.Entity<PeriodoPago>().HasData(DefaultData.GetDefaultDataPeriodoPago());
            modelBuilder.Entity<Direccion>().HasData(DefaultData.GetDefaultDataDireccion());
            modelBuilder.Entity<Usuario>().HasData(DefaultData.GetDefaultDataUsuario());
            modelBuilder.Entity<Empresa>().HasData(DefaultData.GetDefaultDataEmpresa());          
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Cliente>())
            {
                entry.Entity.FechaCreado = entry.State switch
                {
                    EntityState.Added => DateTime.UtcNow,
                    _ => entry.Entity.FechaCreado
                };
                entry.Entity.FechaActualizado = entry.State switch
                {
                    EntityState.Modified => DateTime.UtcNow,
                    _ => entry.Entity.FechaCreado
                };
            }

            foreach (var entry in ChangeTracker.Entries<Usuario>())
            {
                entry.Entity.FechaCreado = entry.State switch
                {
                    EntityState.Added => DateTime.UtcNow,
                    _ => entry.Entity.FechaCreado
                };
                entry.Entity.FechaActualizado = entry.State switch
                {
                    EntityState.Modified => DateTime.UtcNow,
                    _ => entry.Entity.FechaCreado
                };
            }

            foreach (var entry in ChangeTracker.Entries<Empresa>())
            {
                entry.Entity.FechaCreado = entry.State switch
                {
                    EntityState.Added => DateTime.UtcNow,
                    _ => entry.Entity.FechaCreado
                };
                entry.Entity.FechaActualizado = entry.State switch
                {
                    EntityState.Modified => DateTime.UtcNow,
                    _ => entry.Entity.FechaActualizado
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
