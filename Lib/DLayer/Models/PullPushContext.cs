using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DLayer.Models;

public partial class PullPushContext : DbContext
{
    public PullPushContext()
    {
    }

    public PullPushContext(DbContextOptions<PullPushContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MBank> MBanks { get; set; }

    public virtual DbSet<MSubject> MSubjects { get; set; }

    public virtual DbSet<TPulPush> TPulPushes { get; set; }

    public virtual DbSet<TSubContent> TSubContents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Public\\Documents\\Data\\DB\\PullPush.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MBank>(entity =>
        {
            entity.ToTable("M_Bank");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<MSubject>(entity =>
        {
            entity.ToTable("M_Subject");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DeleteFlg).HasDefaultValueSql("'false'");
            entity.Property(e => e.EnableFlg).HasDefaultValueSql("'true'");
            entity.Property(e => e.TaxTargetFlg).HasDefaultValueSql("'false'");
        });

        modelBuilder.Entity<TPulPush>(entity =>
        {
            entity.ToTable("T_PulPush");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FromBank).HasDefaultValueSql("'false'");
            entity.Property(e => e.Pull).HasDefaultValueSql("'0'");
            entity.Property(e => e.Push).HasDefaultValueSql("'0'");
            entity.Property(e => e.Rule).HasDefaultValueSql("'-1'");
        });

        modelBuilder.Entity<TSubContent>(entity =>
        {
            entity.ToTable("T_SubContent");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
