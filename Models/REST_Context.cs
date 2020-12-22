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
        public DbSet<User> users { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Elevator> elevators { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Lead> leads { get; set; }
        public DbSet<Battery> batteries { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<BuildingDetail> building_details { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Quote> quotes { get; set; }
    }
}