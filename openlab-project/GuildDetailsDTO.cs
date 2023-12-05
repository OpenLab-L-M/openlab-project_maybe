namespace openlab_project
{
    public class GuildDetailsDTO
    {
        public int Id { get; set; }
        public string? GuildName { get; set; }
        public string? Description { get; set; }
        public List<UserInfoDTO>? Members { get; set; }
        public int MembersCount { get; set; }
    }
}