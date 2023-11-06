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

        public GuildController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<GuildInfo> GetGuildInformation()
        {
            IEnumerable<GuildInfo> dbGuilds = _context.Guilds;

            return dbGuilds.Select(dbGuilds => new GuildInfo
            {
                Name = dbGuilds.Name,
                Id = dbGuilds.Id,
                MembersCount = GetguildMembersCount(dbGuilds.Id),
                GuildMaxMembers = dbGuilds.GuildMaxMembers,
                Description = dbGuilds.Description,
                

            });
        }


        private int GetguildMembersCount(int guildId)
        {
            IQueryable<ApplicationUser> users = _context.Users.Include(applicationUser => applicationUser.Guild).AsNoTracking();

            return users.Where(u => u.Guild.Id == guildId).Count();
        }

    }
}
