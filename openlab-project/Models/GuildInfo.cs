using System.ComponentModel.DataAnnotations;

namespace openlab_project.Models
{
    public class GuildInfo
    {
        [Key]
        public int Id { get; set; }
        public string? GuildName { get; set; }
        public ICollection<ApplicationUser>? GuildMembers { get; } = new List<ApplicationUser>();
        public int GuildMaxMembers { get; set; }
        public string? Description { get; set; }
        

    }
}
