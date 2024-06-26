﻿namespace VideoPortal.API.Models.DTO.Login
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
