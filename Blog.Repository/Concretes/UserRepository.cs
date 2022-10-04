using Blog.Core;
using Blog.Dal.Concrete;
using Blog.Entities;
using Blog.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Concretes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BlogContext context) : base(context)
        {
        }
    }
}
