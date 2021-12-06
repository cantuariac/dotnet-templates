﻿using Core.Business.Models;

namespace ExampleApi.Models
{
    public class User : Entity<int>
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }

    public class UserDto
    {
        public string Username { get; set; }
    }
}