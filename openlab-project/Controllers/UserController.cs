using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using openlab_project.Data;
using openlab_project.Models;
using System.Security.Claims;

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
        public ActionResult<UserInfoDTO> Get()
        {
            var myUser = GetCurrentUser();
            var mUserInfo = new UserInfoDTO
            {
                UserId = myUser.Id,
                UserName = myUser.UserName,
                Xp = myUser.Xp,
                Guild = myUser?.GuildInfo.GuildName,
            };

            return mUserInfo;
        }
        private ApplicationUser GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser? user = _context.Users
                .Include(user => user.GuildInfo)
                .SingleOrDefault(user => user.Id == userId);

            return user!;
        }
    }
}
