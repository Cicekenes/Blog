using Blog.Dal.Concrete;
using Blog.Dtos.UserRequest;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class UserService
    {
        BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(UserRegisterRequest request)
        {
            if (_context.Users.Any(x=>x.Email==request.Email))
            {
                return false;
            }
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = request.Email,
                PasswordHash=Convert.ToByte(passwordHash),
                PasswordSalt=Convert.ToByte(passwordSalt),
                VerificationToken=CreateRandomToken()
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
