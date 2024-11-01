using AcademyWebsite.Models;
using AcademyWebsite.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebsite.Data;

public class AcademyWebsiteContext : IdentityDbContext<IdentityUser>
{
    public AcademyWebsiteContext(DbContextOptions<AcademyWebsiteContext> options)
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
