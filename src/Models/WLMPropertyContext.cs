using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace UK_Property_API.Models
{
    public partial class WlmPropertyContext : DbContext
    {
        public WlmPropertyContext() { }


        public WlmPropertyContext(DbContextOptions<WlmPropertyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PpdTransaction> PpdTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("connectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PpdTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionUniqueIdentifier)
                    .HasName("PK_GOVPricePaidData_TransactionUniqueIdentifier");

                entity.ToTable("GOVPricePaidData");

                entity.Property(e => e.TransactionUniqueIdentifier)
                    .HasColumnName("Transaction unique identifier")
                    .ValueGeneratedNever();

                entity.Property(e => e.County)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfTransfer)
                    .HasColumnName("Date of Transfer")
                    .HasColumnType("datetime");

                entity.Property(e => e.District)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Locality)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OldNew)
                    .HasColumnName("Old/New")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Paon)
                    .HasColumnName("PAON")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PpdCategoryType)
                    .HasColumnName("PPD Category Type")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasColumnName("Property Type")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("Record Status")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Saon)
                    .HasColumnName("SAON")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TownCity)
                    .HasColumnName("Town/City")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
