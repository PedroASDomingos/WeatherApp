using Microsoft.AspNetCore.Identity;

namespace WeatherAppSite.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
