using AcademyWebsite.SeedData;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebsite.Models
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<RegistrationData> RegistrationData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RegistrationConfigoration());
           
            base.OnModelCreating(builder);
        }

    }
}
