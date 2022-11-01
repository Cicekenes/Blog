using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class User:Base
    {
        [Required,StringLength(25,MinimumLength =2)]
        public string? Name { get; set; }
        [Required, StringLength(25, MinimumLength = 2)]
        public string? Surname { get; set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
        [Required, EmailAddress,StringLength(100,MinimumLength =11)]
        public string? Email { get; set; }
        [Required,StringLength(30,MinimumLength =5)]
        public string? Username { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        //Password Salt= PasswordHash+Salting
        public byte[] PasswordSalt { get; set; } = new byte[32];
		public string? VerificationToken { get; set; }
        public DateTime VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime ResetTokenExpires { get; set; }
        public int Role { get; set; } = (int)Roles.User;
		public DateTime BannedTime { get; set; }

	}
}
