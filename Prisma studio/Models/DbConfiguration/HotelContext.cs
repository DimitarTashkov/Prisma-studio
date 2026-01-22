using HotelOazis.Models.Enumerations;
using HotelOazis.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HotelOazis.Models.DbConfiguration
{
    public class HotelContext : DbContext
    {
        public HotelContext()
        {
            
        }
        public HotelContext(DbContextOptions options) :
            base(options) 
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasIndex(r => r.Number)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            string resourcesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");


            // Seed Rooms
            var rooms = new List<Room>
            {
                new Room { Id = Guid.NewGuid(), Number = 101, Type = RoomType.Single, Price = 80.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "singleRoom1.jpg"), Description = "Cozy single room with a city view." },
                new Room { Id = Guid.NewGuid(), Number = 102, Type = RoomType.Double, Price = 120.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "doubleRoom.jpg"), Description = "Spacious double room with modern amenities." },
                new Room { Id = Guid.NewGuid(), Number = 103, Type = RoomType.Triple, Price = 200.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "tripleRoom1.jpg"), Description = "Luxury suite with a king-sized bed and ocean view." },
                new Room { Id = Guid.NewGuid(), Number = 104, Type = RoomType.Single, Price = 75.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "singleRoom2.jpg"), Description = "Comfortable single room with free Wi-Fi." },
                new Room { Id = Guid.NewGuid(), Number = 105, Type = RoomType.Double, Price = 130.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "doubleRoom2.jpg"), Description = "Elegant double room with a balcony." },
                new Room { Id = Guid.NewGuid(), Number = 106, Type = RoomType.Quad, Price = 220.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "quadRoom.jpg"), Description = "Premium suite with a private hot tub." },
                new Room { Id = Guid.NewGuid(), Number = 107, Type = RoomType.Single, Price = 85.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "singleRoom3.jpg"), Description = "Modern single room with a work desk." },
                new Room { Id = Guid.NewGuid(), Number = 108, Type = RoomType.Double, Price = 140.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "doubleRoom3.jpg"), Description = "Stylish double room with a city skyline view." },
                new Room { Id = Guid.NewGuid(), Number = 109, Type = RoomType.Family, Price = 250.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "familyRoom.jpg"), Description = "Exclusive suite with a private lounge area." },
                new Room { Id = Guid.NewGuid(), Number = 110, Type = RoomType.Double, Price = 135.00m, IsAvailable = true, Picture = Path.Combine(resourcesFolder, "doubleRoom4.jpg"), Description = "Charming double room with artistic decor." }
            };


            modelBuilder.Entity<Room>().HasData(rooms);

            // Seed Services
            var services = new List<Service>
            {
                new Service { Id = Guid.NewGuid(), Name = "Spa Treatment", Description = "Relaxing full-body spa experience." },
                new Service { Id = Guid.NewGuid(), Name = "Gym Access", Description = "Unlimited access to our state-of-the-art fitness center." },
                new Service { Id = Guid.NewGuid(), Name = "Airport Shuttle", Description = "Convenient transport to and from the airport." },
                new Service { Id = Guid.NewGuid(), Name = "Breakfast Buffet", Description = "Delicious breakfast with a variety of options." },
                new Service { Id = Guid.NewGuid(), Name = "Room Service", Description = "24/7 room service with gourmet meals." },
                new Service { Id = Guid.NewGuid(), Name = "Laundry Service", Description = "Same-day laundry and dry-cleaning services." },
                new Service { Id = Guid.NewGuid(), Name = "City Tour", Description = "Guided tour of local attractions." },
                new Service { Id = Guid.NewGuid(), Name = "Wi-Fi Access", Description = "High-speed internet available in all areas." },
                new Service { Id = Guid.NewGuid(), Name = "Conference Room", Description = "Fully equipped meeting and conference facilities." },
                new Service { Id = Guid.NewGuid(), Name = "Swimming Pool", Description = "Access to our indoor heated pool." }
            };
            modelBuilder.Entity<Service>().HasData(services);

            // Seed Users
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Username = "AliceSmith", Password = "hashedpassword", Age = 28, Email = "alice@example.com", AvatarUrl = Path.Combine(resourcesFolder, "womanAvatar.jpg") },
                new User { Id = Guid.NewGuid(), Username = "BobJohnson", Password = "hashedpassword", Age = 35, Email = "bob@example.com", AvatarUrl = Path.Combine(resourcesFolder, "manAvatar.jpg") },
                new User { Id = Guid.NewGuid(), Username = "CharlieBrown", Password = "hashedpassword", Age = 40, Email = "charlie@example.com", AvatarUrl = Path.Combine(resourcesFolder, "womanAvatar.jpg") },
                new User { Id = Guid.NewGuid(), Username = "DianaWhite", Password = "hashedpassword", Age = 30, Email = "diana@example.com", AvatarUrl = Path.Combine(resourcesFolder, "womanAvatar.jpg") },
                new User { Id = Guid.NewGuid(), Username = "EdwardBlack", Password = "hashedpassword", Age = 33, Email = "edward@example.com", AvatarUrl = Path.Combine(resourcesFolder, "manAvatar.jpg") }
            };

            modelBuilder.Entity<User>().HasData(users);

            // Seed Reservations (2 per user)
            var reservations = new List<Reservation>();
            var rand = new Random();
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    reservations.Add(new Reservation
                    {
                        Id = Guid.NewGuid(),
                        UserId = users[i].Id,
                        RoomId = rooms[(i * 2 + j) % rooms.Count].Id,
                        CheckInDate = DateTime.UtcNow.AddDays(rand.Next(1, 10)),
                        CheckOutDate = DateTime.UtcNow.AddDays(rand.Next(11, 20))
                    });
                }
            }
            modelBuilder.Entity<Reservation>().HasData(reservations);

            // Seed Reviews (1 per user)
            var reviews = new List<Review>();
            for (int i = 0; i < users.Count; i++)
            {
                reviews.Add(new Review
                {
                    Id = Guid.NewGuid(),
                    UserId = users[i].Id,
                    Message = $"Amazing stay! {users[i].Username} had a wonderful experience.",
                    Rating = rand.Next(3, 6), // Ratings between 3 and 5
                    MessageStatus = FeedbackStatus.Verified,
                    PublishedOn = DateTime.UtcNow
                });
            }
            modelBuilder.Entity<Review>().HasData(reviews);
        }
    }
}
