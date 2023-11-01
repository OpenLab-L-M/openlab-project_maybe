using System.ComponentModel.DataAnnotations;

namespace openlab_project.Models
{
    public class GuildInfo
    {
        [Key]
        public int Id { get; set; }
        public string? GuildName { get; set; }
        public int GuildMembers {  get; set; }
    }
}
