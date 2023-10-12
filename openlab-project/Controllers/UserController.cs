using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using openlab_project.Models;
using System.Xml.XPath;

namespace openlab_project.Controllers
{

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationUser _pDashboard;
        public UserController(ILogger<UserController> logger, ApplicationUser pDashboard)
        {
            _logger = logger;
            _pDashboard = pDashboard;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var user = new UserInfo();
            {
                user.Xp = 1000;
                user.Guild = "internet warriors";
            };
            return Ok(user);
        }
    }
}
