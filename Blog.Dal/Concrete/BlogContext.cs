using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Concrete
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions  options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
