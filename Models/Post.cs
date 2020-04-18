using System;

namespace DatingApp.API.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
    }
}