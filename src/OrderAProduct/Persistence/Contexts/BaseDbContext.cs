using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Corporate> Corporates { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("HackathonProjectConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corporate>(a =>
            {
                a.ToTable("Corporates").HasKey(fk => fk.Id);
                a.Property(pk => pk.Id).HasColumnName("Id");
                a.Property(pk => pk.CorporateName).HasColumnName("CorporateName");
                a.Property(pk => pk.OrderState).HasColumnName("OrderState");
                a.Property(pk => pk.StartOrderTime).HasColumnName("StartOrderTime");
                a.Property(pk => pk.EndOrderTime).HasColumnName("EndOrderTime");
            });

            Corporate[] corporateSeeds =
            {
                new(1, "Getir", true, 
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 08, 30, 00),
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 11, 00, 00)),
                new(2, "YemekSepeti", true, 
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 11, 00, 00),
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 13, 30, 00)),
                new(3, "Trendyol", true, 
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 13, 30, 00),
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 16, 00, 00)),
            };
            modelBuilder.Entity<Corporate>().HasData(corporateSeeds);
        }
    }
}
