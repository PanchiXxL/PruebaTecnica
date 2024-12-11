using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sistema_Creditos.Model.Models;

namespace Sistema_Creditos.Model.Context;

public partial class CreditosContext : DbContext
{
    public CreditosContext()
    {
    }

    public CreditosContext(DbContextOptions<CreditosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Operaciones> Operaciones { get; set; }

    public virtual DbSet<TipoCredito> TipoCreditos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operaciones>(entity =>
        {
            entity.HasKey(e => e.OperacionId).HasName("PK__Operacio__8A668AF77E6D42E2");

            entity.Property(e => e.OperacionId).HasColumnName("OperacionID");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Monto).HasColumnType("money");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoCredito)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoCredito>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__TipoCred__06370DAD19BFBE1A");

            entity.ToTable("TipoCredito");

            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
