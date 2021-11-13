using System.ComponentModel.DataAnnotations;

namespace WeatherAppSite.Models
{
    public class RecoverPassViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
