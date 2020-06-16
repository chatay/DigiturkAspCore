using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digiturk.data.Model
{
    public class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        [Key]
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public string Role { get; set; }
        public string UserType { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }
        public string AboutMe { get; set; }
        public DateTime LastSeen { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string VkUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public Byte ShowEmailOnProfile { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }

    }
}