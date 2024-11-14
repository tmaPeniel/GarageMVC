using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GarageASP.NetMVC.Models;

public partial class GarageManagementContext : DbContext
{
    public GarageManagementContext()
    {
    }

    public GarageManagementContext(DbContextOptions<GarageManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Voitures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=GMConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Immatriculation).HasName("PK__Voiture__E15BDED31EB5E29A");

            entity.ToTable("Voiture");

            entity.Property(e => e.Immatriculation).HasMaxLength(50);
            entity.Property(e => e.Etat).HasMaxLength(50);
            entity.Property(e => e.Marque).HasMaxLength(50);
            entity.Property(e => e.Modele).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
