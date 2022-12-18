using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

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
                a.ToTable("Corporates").HasKey(k => k.Id);
                a.Property(pk => pk.Id).HasColumnName("Id");
                a.Property(pk => pk.CorporateName).HasColumnName("CorporateName");
                a.Property(pk => pk.OrderState).HasColumnName("OrderState");
                a.Property(pk => pk.StartOrderTime).HasColumnName("StartOrderTime");
                a.Property(pk => pk.EndOrderTime).HasColumnName("EndOrderTime");
                a.HasMany(fk => fk.Products);
            });

            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(k => k.Id);
                a.Property(pk => pk.Id).HasColumnName("Id");
                a.Property(pk => pk.CorporateName).HasColumnName("CorporateName");
                a.Property(pk => pk.ProductName).HasColumnName("ProductName");
                a.Property(pk => pk.Stock).HasColumnName("Stock");
                a.Property(pk => pk.UnitPrice).HasColumnName("UnitPrice");
                a.HasOne(fk => fk.Corporate);
            });

            modelBuilder.Entity<Order>(a =>
            {
                a.ToTable("Orders").HasKey(k => k.Id);
                a.Property(pk => pk.Id).HasColumnName("Id");
                a.Property(pk => pk.ClientName).HasColumnName("ClientName");
                a.Property(pk => pk.OrderDate).HasColumnName("OrderDate");
                a.HasOne(fk => fk.Corporate);
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

            Product[] productSeeds =
            {
                new(1, "YemekSepeti", "Tantuni", 5, 45f),
                new(2, "YemekSepeti", "Döner", 5, 40f),
                new(3, "YemekSepeti", "Tavuklu Makarna", 5, 40f),
            };
            modelBuilder.Entity<Product>().HasData(productSeeds);

            Order[] orderSeeds =
            {
                new(1, 3, 3, "Cihan Vural", DateTime.Now),
                new(2, 3, 2, "Cihan Vural", DateTime.Now),
                new(3, 3, 1, "Cihan Vural", DateTime.Now),
            };
            modelBuilder.Entity<Order>().HasData(orderSeeds);
        }
    }
}
