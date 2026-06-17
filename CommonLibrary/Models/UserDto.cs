using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        //public List<string> Roles { get; set; } = new();
    }
}
