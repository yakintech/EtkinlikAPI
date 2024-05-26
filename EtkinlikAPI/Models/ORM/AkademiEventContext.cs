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
    }
}





