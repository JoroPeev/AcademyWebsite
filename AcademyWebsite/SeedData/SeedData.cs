using AcademyWebsite.Models;

namespace AcademyWebsite.SeedData
{
    internal class SeedData
    {

        public RegistrationData RegistredUser { get; set; }

        public SeedData()
        {
            SeedRegistrationData();
        }

        private void SeedRegistrationData() 
        {

            RegistredUser = new RegistrationData
            {
                Id = 1,
                ChildAge = 5,
                EmailAddress = "JonDoe@gmail.com",
                ChildName = "Penka",
                ParentName = "Stanka",
                PhoneNumber = "1234567890",
            };
        
        
        }

    }
}
