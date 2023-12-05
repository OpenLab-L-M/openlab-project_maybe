using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using openlab_project.Data;
using openlab_project.Models;
using System.Security.Claims;

namespace openlab_project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GuildController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuildController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public IEnumerable<GuildDTO> GetGuildInformation()
        {
            IEnumerable<GuildInfo> dbGuilds = _context.Guild;

            return dbGuilds.Select(dbGuilds => new GuildDTO
            {
                Name = dbGuilds.GuildName,
                Id = dbGuilds.Id,
                MembersCount = GetGuildMembers(dbGuilds.Id).Count(),
                GuildMaxMembers = dbGuilds.GuildMaxMembers,
                Description = dbGuilds.Description,
            });
        }

        [HttpGet("{guildId:int}")]
        public IActionResult GetGuildDetails(int guildId)
        {
            var guild = _context.Guild.FirstOrDefault(guildInfo => guildInfo.Id == guildId);

            if (guild == null)
            {
                return NotFound($"guild with id: {guildId} not found");
            }

            var guildMembers = GetGuildMembers(guildId);
            var guildDetails = CreateGuildDetailsDTO(guild);

            return Ok(guildDetails);
        }

        [HttpPost("join")]
        public ActionResult<GuildDetailsDTO> JoinGuild([FromBody] int guildIdToJoin)
        {
            try
            {
                var user = GetCurrentUser();

                GuildInfo? guildToJoin = _context.Guild.FirstOrDefault(g => g.Id == guildIdToJoin);

                if (user.GuildInfo == null)
                {
                    user.GuildInfo = guildToJoin;
                    _context.SaveChanges();

                    var guildDetailsDTO = CreateGuildDetailsDTO(guildToJoin);

                    return Ok(guildDetailsDTO);
                }
                else
                {
                    return BadRequest(new { Message = "User is already a member of a guild." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        [HttpGet("leave")]
        public ActionResult<GuildDetailsDTO> LeaveGuild()
        {
            try
            {
                var user = GetCurrentUser();

                var guildDetails = CreateGuildDetailsDTO(user.GuildInfo);

                user.GuildInfo = null;
                _context.SaveChanges();

                return Ok(guildDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
            }
        }

        private IEnumerable<ApplicationUser> GetGuildMembers(int dbGuildId)
        {
            IEnumerable<ApplicationUser> users = _context.Users.Include(applicationUser => applicationUser.GuildInfo);

            return users
                .Where(applicationUser => applicationUser.GuildInfo != null && applicationUser.GuildInfo.Id == dbGuildId)
                .ToList();
        }

        private ApplicationUser GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser? user = _context.Users
                .Include(user => user.GuildInfo)
                .SingleOrDefault(user => user.Id == userId);

            return user!;
        }

        private static GuildDetailsDTO CreateGuildDetailsDTO(GuildInfo guildInfo)
        {
            return new GuildDetailsDTO
            {
                Id = guildInfo.Id,
                GuildName = guildInfo.GuildName,
                Description = guildInfo.Description,
                Members = guildInfo.GuildMembers.Select(member => new UserInfoDTO
                {
                    UserId = member.Id,
                    UserName = member.UserName,
                    Xp = member.Xp,
                }).ToList(),
            };
        }
    }
}