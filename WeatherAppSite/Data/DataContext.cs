
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherAppSite.Data.Entities;

namespace AuthenticationApi.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
