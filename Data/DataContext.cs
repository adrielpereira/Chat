using Microsoft.EntityFrameworkCore;
using WebChatQJW.Core.Models;

namespace WebChatQJW.Core.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;database=qjwchat;user=user;password=senhabd");
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
