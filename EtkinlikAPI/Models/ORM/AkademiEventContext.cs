using Microsoft.EntityFrameworkCore;

namespace EtkinlikAPI.Models.ORM
{
    public class AkademiEventContext : DbContext
    {
        public AkademiEventContext(DbContextOptions<AkademiEventContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityImages> ActivityImages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}





