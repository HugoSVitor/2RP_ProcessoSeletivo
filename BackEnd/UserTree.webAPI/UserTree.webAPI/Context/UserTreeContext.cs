using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserTree.webAPI.Domains;

#nullable disable

namespace UserTree.webAPI.Context
{
    public partial class UserTreeContext : DbContext
    {
        public UserTreeContext()
        {
        }

        public UserTreeContext(DbContextOptions<UserTreeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QIG7H5C\\SQLEXPRESS; Initial Catalog=USERTREE; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoU)
                    .HasName("PK__TipoUsua__CD5FEBACD21DBAEE");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TipoU, "UQ__TipoUsua__E422314E442550BB")
                    .IsUnique();

                entity.Property(e => e.IdTipoU)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoU");

                entity.Property(e => e.TipoU)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipoU");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6D99BE871");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E616433BE91E8")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoU).HasColumnName("idTipoU");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.StatusU).HasColumnName("statusU");

                entity.HasOne(d => d.IdTipoUNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoU)
                    .HasConstraintName("FK__Usuarios__idTipo__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
