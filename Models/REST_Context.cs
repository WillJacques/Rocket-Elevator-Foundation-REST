using Microsoft.EntityFrameworkCore;

namespace REST_API.Models
{
    public class REST_Context : DbContext
    {
        public REST_Context(DbContextOptions<REST_Context> options)
            : base(options)
        {
        }

        public DbSet<intervention> interventions { get; set; }
    }
}