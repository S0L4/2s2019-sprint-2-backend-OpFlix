using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Classificacoes> Classificacoes { get; set; }
        public virtual DbSet<Favoritos> Favoritos { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<TipoLancamento> TipoLancamento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_OpFlix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B20D0ED06D")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Classificacoes>(entity =>
            {
                entity.HasKey(e => e.IdClassificacao);

                entity.Property(e => e.Idade)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Favoritos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.IdLancamentoNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdLancamento)
                    .HasConstraintName("FK__Favoritos__IdLan__2A164134");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Favoritos__IdUsu__29221CFB");
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__Lancamen__7B406B56F010EE3E")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("datetime");

                entity.Property(e => e.Sinopse)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__6EF57B66");

                entity.HasOne(d => d.IdClassificaoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdClassificao)
                    .HasConstraintName("FK__Lancament__IdCla__6FE99F9F");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Lancament__IdPla__6E01572D");

                entity.HasOne(d => d.IdTipoLancamentoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdTipoLancamento)
                    .HasConstraintName("FK__Lancament__IdTip__70DDC3D8");
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B2B1627660")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoLancamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoLancamento);

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TipoLanc__8E762CB4ACAA87C5")
                    .IsUnique();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TipoUsua__8E762CB444C1B57C")
                    .IsUnique();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__6A30C649");
            });
        }
    }
}
