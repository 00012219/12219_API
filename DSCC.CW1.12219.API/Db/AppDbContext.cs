using DSCC.CW1._12219.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._12219.API.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the primary key for the Person entity
            modelBuilder.Entity<Person>()
                .HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
