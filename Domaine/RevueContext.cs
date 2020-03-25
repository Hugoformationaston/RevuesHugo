using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Revues.Domaine
{
    public partial class RevueContext : DbContext
    {
        public RevueContext()
        {
        }

        public RevueContext(DbContextOptions<RevueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Auteurs> Auteurs { get; set; }
        public virtual DbSet<Ecrit> Ecrit { get; set; }
        public virtual DbSet<Numero> Numero { get; set; }
        public virtual DbSet<Revues> Revues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=2306;user=root;password=root;database=bdd_revues", x => x.ServerVersion("10.4.8-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.ToTable("articles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contenu)
                    .HasColumnName("contenu")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Titre)
                    .HasColumnName("titre")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Auteurs>(entity =>
            {
                entity.ToTable("auteurs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Ecrit>(entity =>
            {
                entity.HasKey(e => new { e.AuteursId, e.ArticlesId })
                    .HasName("PRIMARY");

                entity.ToTable("ecrit");

                entity.HasIndex(e => e.ArticlesId)
                    .HasName("fk_auteurs_has_articles_articles1_idx");

                entity.HasIndex(e => e.AuteursId)
                    .HasName("fk_auteurs_has_articles_auteurs1_idx");

                entity.Property(e => e.AuteursId)
                    .HasColumnName("auteurs_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticlesId)
                    .HasColumnName("articles_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Articles)
                    .WithMany(p => p.Ecrit)
                    .HasForeignKey(d => d.ArticlesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_auteurs_has_articles_articles1");

                entity.HasOne(d => d.Auteurs)
                    .WithMany(p => p.Ecrit)
                    .HasForeignKey(d => d.AuteursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_auteurs_has_articles_auteurs1");
            });

            modelBuilder.Entity<Numero>(entity =>
            {
                entity.ToTable("numero");

                entity.HasIndex(e => e.ArticlesId)
                    .HasName("fk_articles_has_revues_articles1_idx");

                entity.HasIndex(e => e.RevuesId)
                    .HasName("fk_articles_has_revues_revues1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticlesId)
                    .HasColumnName("articles_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PageDebut)
                    .HasColumnName("page_debut")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PageFin)
                    .HasColumnName("page_fin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RevuesId)
                    .HasColumnName("revues_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Articles)
                    .WithMany(p => p.Numero)
                    .HasForeignKey(d => d.ArticlesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articles_has_revues_articles1");

                entity.HasOne(d => d.Revues)
                    .WithMany(p => p.Numero)
                    .HasForeignKey(d => d.RevuesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articles_has_revues_revues1");
            });

            modelBuilder.Entity<Revues>(entity =>
            {
                entity.ToTable("revues");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Annee)
                    .HasColumnName("annee")
                    .HasColumnType("date");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
