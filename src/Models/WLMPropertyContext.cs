using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UK_Property_API.Models
{
    public partial class WLMPropertyContext : DbContext
    {
        public WLMPropertyContext()
        {
        }

        public WLMPropertyContext(DbContextOptions<WLMPropertyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GovPricePaidData> GovPricePaidData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:wlmconsulting.database.windows.net,1433;Initial Catalog=WLM-Property;Persist Security Info=False;User ID=alexdgourlay;Password=96e5ff2d11WLM;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GovPricePaidData>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GOV-PricePaidData");

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

                entity.Property(e => e.TransactionUniqueIdentifier).HasColumnName("Transaction unique identifier");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
