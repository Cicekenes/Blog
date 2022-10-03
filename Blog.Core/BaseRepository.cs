using Blog.Dal.Concrete;
using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly BlogContext _blogContext;
        public BaseRepository(BlogContext context)
        {
            _blogContext = context;
        }
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Set().AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(T model)
        {
            await Set().AddRangeAsync(model);
            return true;
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Set().AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
           var query = Set().AsQueryable();
            if(!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Set().AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Set().Where(filter);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Set().Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Set().FindAsync(int.Parse(id));
            return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Set().RemoveRange(datas);
            return true;
        }

        public DbSet<T> Set() => _blogContext.Set<T>();
       

        public bool Update(T model)
        {
            EntityEntry entityEntry= Set().Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
