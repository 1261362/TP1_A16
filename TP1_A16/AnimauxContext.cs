using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TP1_A16.Models;

namespace TP1_A16;

public partial class AnimauxContext : DbContext
{
    public AnimauxContext()
    {
    }

    public AnimauxContext(DbContextOptions<AnimauxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<TypeAnimal> TypeAnimals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Animaux");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3213E83F570BF947");

            entity.ToTable("Client");

            entity.HasIndex(e => e.Courriel, "UQ__Client__049FB20208682FA3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Courriel)
                .HasMaxLength(100)
                .HasColumnName("courriel");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<TypeAnimal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeAnim__3213E83FA7CE48F6");

            entity.ToTable("TypeAnimal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.PrixAnimal).HasColumnName("prixAnimal");
            entity.Property(e => e.QuantiteDisponible).HasColumnName("quantiteDisponible");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
