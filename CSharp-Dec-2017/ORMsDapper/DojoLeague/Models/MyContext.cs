using Microsoft.EntityFrameworkCore;

namespace DojoLeague.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<Ninja> Ninjas {get;set;}
        public DbSet<Dojo> Dojos {get;set;}
    }
}