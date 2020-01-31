using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WlmPropertyAPI.Models
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

        public virtual DbSet<PpdTransaction> PpdTransaction { get; set; }
        public virtual DbSet<UkCounty> UkCounty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration["Data:UKPropertyAPIConnection:ConnectionString"];
                optionsBuilder.UseSqlServer(connectionString,
                    opt => opt.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PpdTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionUniqueIdentifier)
                    .HasName("PK_GOVPricePaidData_TransactionUniqueIdentifier");

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

                entity.HasOne(d => d.CountyNavigation)
                    .WithMany(p => p.PpdTransaction)
                    .HasForeignKey(d => d.County)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PpdTransaction_UkCounty");
            });

            modelBuilder.Entity<UkCounty>(entity =>
            {
                entity.HasKey(e => e.PpdCounty);

                entity.Property(e => e.PpdCounty)
                    .HasColumnName("PPD County")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CeremonialOrPreservedCounty)
                    .HasColumnName("Ceremonial or Preserved County")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
