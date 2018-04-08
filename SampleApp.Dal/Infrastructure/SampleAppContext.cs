using Microsoft.EntityFrameworkCore;
using SampleApp.Dal.Models;

namespace SampleApp.Dal.Infrastructure
{
    public class SampleAppContext : DbContext
    {
        public SampleAppContext(DbContextOptions<SampleAppContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}