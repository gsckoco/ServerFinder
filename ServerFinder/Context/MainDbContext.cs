using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServerFinder.Entities;

namespace ServerFinder.Context;

public partial class MainDbContext : DbContext
{
    public MainDbContext()
    {
    }

    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCompany> TblCompanies { get; set; }

    public virtual DbSet<TblProcessor> TblProcessors { get; set; }

    public virtual DbSet<TblServer> TblServers { get; set; }
    public virtual DbSet<TblRates> TblRates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=password;database=serverfinder");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProcessor>(entity =>
        {
            entity.Property(e => e.BaseFreq).HasDefaultValue(1000);
            entity.Property(e => e.Brand).HasDefaultValue("Intel");
        });

        modelBuilder.Entity<TblServer>(entity =>
        {
            entity.Property(e => e.Bandwidth).HasDefaultValue(1000);
            entity.Property(e => e.ConnectionSpeed).HasDefaultValue(1000);
            entity.Property(e => e.ProcessorCount).HasDefaultValue(1);
            entity.Property(e => e.TotalStorage).HasDefaultValue(1024);
            entity.Property(e => e.Storage).HasDefaultValue("");

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.TblServers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Servers_tbl_Company");

            entity.HasOne(d => d.ProcessorNavigation).WithMany(p => p.TblServers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Servers_tbl_Processors");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
