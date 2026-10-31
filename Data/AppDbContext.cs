using hihi.Models;
using Microsoft.EntityFrameworkCore;

namespace hihi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Request>()
                .HasOne<Client>()
                .WithMany()
                .HasForeignKey(r => r.IdClient);


            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Login = "master07", Password = "12345", Role = "Пользователь", IsBlocked = false },
                new Client { Id = 2, Login = "admin", Password = "admin", Role = "Администратор", IsBlocked = false }
            );

            modelBuilder.Entity<Request>().HasData(
                new Request { Id = 1, Title = "Замена экрана", Content = "iPhone 12", IdClient = 1, CreatedAt = new DateTime(2027, 03, 15) },
                new Request { Id = 2, Title = "Чистка ноутбука", Content = "Lenovo", IdClient = 1, CreatedAt = new DateTime(2027, 03, 16) },
                new Request { Id = 3, Title = "Установка ПО", Content = "Windows 11", IdClient = 2, CreatedAt = new DateTime(2027, 03, 17) }
            );
        }
    }
}
