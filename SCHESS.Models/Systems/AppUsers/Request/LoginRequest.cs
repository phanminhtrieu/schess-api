﻿namespace SCHESS.Models.Systems.AppUsers.Request
{
    public class LoginRequest
    {
        //public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
