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
        public DbSet<Blogg> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public BlogContext(DbContextOptions  options):base(options)
        {

        }

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
            var datas = ChangeTracker.Entries<Base>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                } ;
            }
			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
