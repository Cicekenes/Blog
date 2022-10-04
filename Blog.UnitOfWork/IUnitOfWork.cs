using Blog.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UnitOfWork
{
    public interface IUnitOfWork
    {
        //Repositories
        IBlogRepository _blogRepository { get; }
        ICategoryRepository _categoryRepository { get; }
        ICommentRepository _commentRepository { get; }
        IPostRepository _postRepository { get; }
        IUserRepository _userRepository { get; }
        Task Save();
    }
}
