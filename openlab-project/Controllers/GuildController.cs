using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using openlab_project.Data;
using openlab_project.Models;

namespace openlab_project.Controllers
{
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
                MembersCount = GetGuildMembersCount(dbGuilds.Id),
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

            var guildDetails = new GuildDetailsDTO
            {
                Id = guild.Id,
                GuildName = guild.GuildName,
                Description = guild.Description,
                Members = guildMembers.Select(member => new UserInfoDTO
                {
                    UserId = member.Id,
                    UserName = member.UserName,
                    Xp = member.Xp,
                }).ToList(),
            };

            return Ok(guildDetails);
        }

        private IEnumerable<ApplicationUser> GetGuildMembers(int dbGuildId)
        {
            IEnumerable<ApplicationUser> users = _context.Users.Include(applicationUser => applicationUser.GuildInfo);

            return users
                .Where(applicationUser => applicationUser.GuildInfo != null && applicationUser.GuildInfo.Id == dbGuildId)
                .ToList();
        }

        private int GetGuildMembersCount(int guildId)
        {
            IQueryable<ApplicationUser> users = _context.Users.Include(applicationUser => applicationUser.GuildInfo).AsNoTracking();

            return users.Count(u => u.GuildInfo.Id == guildId);
        }
    }
}

