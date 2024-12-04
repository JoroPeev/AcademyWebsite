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
    public DbSet<Message> Messages { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Children> Childrens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RegistrationConfiguration());

        builder.Entity<Children>()
         .HasOne(c => c.Course)
         .WithMany(c => c.Childrens)
         .HasForeignKey(c => c.CourseId)
         .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(builder);
    }
}
