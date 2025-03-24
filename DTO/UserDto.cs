﻿using UserBlogAPI.Models;

namespace UserBlogAPI.DTO
{
    public class UserDto
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;


    }

}
