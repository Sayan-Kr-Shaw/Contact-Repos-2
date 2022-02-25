using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactsDAL.Models
{
    public partial class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
        {
        }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<EmailId> EmailIds { get; set; } = null!;
        public virtual DbSet<TelephoneNumber> TelephoneNumbers { get; set; } = null!;

        public DbSet<ContactDetails> ContactDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\ProjectModels;Initial Catalog=ContactsDb;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.MarriageAnniversary)
                    .HasColumnType("date")
                    .HasColumnName("Marriage Anniversary");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photograph).HasColumnType("image");
            });

            modelBuilder.Entity<EmailId>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmailId");

                entity.Property(e => e.ContactId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmailId");

                entity.HasOne(d => d.Contact)
                    .WithMany()
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__EmailId__Contact__38996AB5");
            });

            modelBuilder.Entity<TelephoneNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Telephone Number");

                entity.Property(e => e.Classification)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("classification");

                entity.Property(e => e.ContactId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber1)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Telephone Number");

                entity.HasOne(d => d.Contact)
                    .WithMany()
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__Telephone__Conta__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
