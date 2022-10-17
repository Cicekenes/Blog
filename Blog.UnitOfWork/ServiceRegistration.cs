using Blog.Repository.Abstracts;
using Blog.Repository.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UnitOfWork
{
    public static class ServiceRegistration
    {
        public static void AddIoC(this IServiceCollection service)
        {
            service.AddScoped<IBlogRepository, BlogRepository>();
            service.AddScoped<ICategoryRepository,CategoryRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IPostRepository,PostRepository>();
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}
