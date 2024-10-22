using AcademyWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyWebsite.SeedData
{
    internal class RegistrationConfigoration: IEntityTypeConfiguration<RegistrationData>
    {
        public void Configure(EntityTypeBuilder<RegistrationData> builder)
        {
            var data = new SeedData();

            builder.HasData([data.RegistredUser]);
        }



    }
}
