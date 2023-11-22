﻿using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<GuildDTO> GetGuildInformation()
        {
            IEnumerable<GuildInfo> dbGuilds = _context.Guild;

            return dbGuilds.Select(dbGuilds => new GuildDTO
            {
                Name = dbGuilds.GuildName,
                Id = dbGuilds.Id,
                MembersCount = GetguildMembersCount(dbGuilds.Id),
                GuildMaxMembers = dbGuilds.GuildMaxMembers,
                Description = dbGuilds.Description,              
            });
        }
        private int GetguildMembersCount(int guildId)
        {
            IQueryable<ApplicationUser> users = _context.Users.Include(applicationUser => applicationUser.GuildInfo).AsNoTracking();

            return users.Where(u => u.GuildInfo.Id == guildId).Count();
        }

        [HttpGet("{guildId}")]
        public IActionResult GetGuildDetails(int guildId)
        {
            var guild = _context.Guild.Find(guildId);


            var guildDetails = new GuildDetailsDTO
            {
                Id = guild.Id,
                UserName = guild.GuildName,
                Description = guild.Description,
                /*Members = guild.GuildMembers.Select(member => new UserInfoDTO
                {
                    Xp = member.Xp
                }).ToList(),*/
            };

            return Ok(guildDetails);
        }

        private int GetGuildMembersCount(int guildId)
        {
            return _context.Users.Count(u => u.GuildInfo.Id == guildId);
        }

    }
}

