using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<ReadyTrip> ReadyTrips { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserType)
                .WithMany()
                .HasForeignKey(u => u.UserTypeID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BookingType)
                .WithMany()
                .HasForeignKey(b => b.BookingTypeID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.ReadyTrip)
                .WithMany()
                .HasForeignKey(b => b.TripID);

            modelBuilder.Entity<ReadyTrip>()
                .HasKey(r => r.TripID);

            modelBuilder.Entity<BookingType>()
                .HasKey(bt => bt.BookingTypeID);

            modelBuilder.Entity<UserType>()
                .HasKey(ut => ut.UserTypeID);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingID);

            modelBuilder.Entity<Driver>()
                .HasKey(d => d.DriverID);
        }
    }
}
