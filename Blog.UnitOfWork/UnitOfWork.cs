using Blog.Dal.Concrete;
using Blog.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;

        public UnitOfWork(BlogContext context, IBlogRepository blogRepository, ICategoryRepository categoryRepository, ICommentRepository commentRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _context = context;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public IBlogRepository _blogRepository { get; private set; }

        public ICategoryRepository _categoryRepository { get; private set; }

        public ICommentRepository _commentRepository { get; private set; }

        public IPostRepository _postRepository { get; private set; }

        public IUserRepository _userRepository { get; private set; }

		public void Save()
		{
            _context.SaveChanges();
		}

		public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
