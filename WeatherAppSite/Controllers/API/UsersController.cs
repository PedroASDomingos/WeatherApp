using AuthenticationApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAppSite.Data.Entities;
using WeatherAppSite.Helpers;
using WeatherAppSite.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAppSite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;

        public UsersController(DataContext context, IUserHelper userHelper, IMailHelper mailHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        // GET: api/Users/
        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            return await _userHelper.GetUserByEmailAsync(email);

        }

        [HttpGet]
        [Route("{email}/{password}")]
        public async Task<bool> CheckifUserExist(string email, string password)
        {
            return await _userHelper.CheckifUserAndPasswordIsCorrect(email, password);

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(RegisterNewUserMobailViewModel user)
        {
            var newuser = new User
            {
                FirstName = "firstname",
                LastName = "lastname",
                UserName = user.Email,
                Email = user.Email
            };

            await _userHelper.AddUserAsync(newuser, user.Password);

            string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(newuser);

            string tokenLink = Url.Action("ConfirmEmail", "Account", new
            {
                userid = newuser.Id,
                token = myToken
            }, protocol: HttpContext.Request.Scheme);

            Response response = _mailHelper.SendEmail(newuser.Email, "Email confirmation", $"<h1>Email Confirmation</h1>" +
                       $"To allow the user, " +
                       $"plase click in this link:</br></br><a href = \"{tokenLink}\">Confirm Email</a>");

            if (response.IsSuccess)
            {
                return CreatedAtAction("GetUser", new { id = newuser.Id }, newuser);
            }

            return CreatedAtAction("GetUser", new { id = newuser.Id }, newuser);
        }

    }
}
