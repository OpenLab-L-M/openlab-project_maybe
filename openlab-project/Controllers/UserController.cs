using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using openlab_project.Data;
using openlab_project.Models;
using System.Security.Claims;
using System.Xml.XPath;

namespace openlab_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<UserInfo> Get()
        {

            var myUser = GetCurrentUser();
            var mUserInfo = new UserInfo
            {
                Xp = myUser.Xp,
                Guild = myUser?.GuildInfo?.GuildName,


            };
            return mUserInfo;
        }
        private Models.ApplicationUser GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Models.ApplicationUser? user = _context.Users
                .Include(user => user.GuildInfo)
                .SingleOrDefault(user => user.Id == userId);

            return user!;
        }

    }
}
