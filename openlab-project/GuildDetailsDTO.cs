﻿namespace openlab_project
{
    public class GuildDetailsDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }        
        public List<UserInfoDTO>? Members { get; set; }
    }
}
