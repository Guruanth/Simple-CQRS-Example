using Microsoft.EntityFrameworkCore;
using SampleApp.Dal.Models;

namespace SampleApp.Dal.Infrastructure
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}