using blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace blog.Data
{
    public class Db : DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public const string ConnectStrring = @"Data Source=CET-DESK-032;Initial Catalog=blog;User ID=sa;Password=Hoang12a9";


        //Tạo ILoggerFactory
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug);
            //.AddConsole();
        });

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity => {
                entity.HasIndex(p => p.Slug);
            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStrring);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
