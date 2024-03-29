﻿namespace RitualServer.Model
{
    public class UserWithRole
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public byte[]? Image { get; set; }
    }
}
