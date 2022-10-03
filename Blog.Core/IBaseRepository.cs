using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public interface IBaseRepository<T> where T:Base
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(T model);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        IQueryable<T> GetAll(bool tracking=true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> filter,bool tracking=true);
        Task<T> GetSingleAsync(Expression<Func<T,bool>> method,bool tracking=true);
        Task<T> GetByIdAsync(string id,bool tracking=true);
        DbSet<T> Set();
    }
}
