
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WeatherAppSite.Data.Entities;

namespace WeatherAppSite.Models
{
    public class RegisterNewUserViewModel : User
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }

        [Display(Name = "User photo")]
        public IFormFile ImageFile { get; set; }
    }
}
