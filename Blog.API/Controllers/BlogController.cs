using Blog.Dtos.BlogDtos;
using Blog.Entities;
using Blog.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BlogController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet(Name =nameof(GetAll))]
        [ProducesResponseType(typeof(BlogListDto),200)]
        public IEnumerable<Blogg> GetAll(bool tracking=true)
        {
            List<BlogListDto> blog = _uow._blogRepository.GetAll(tracking).Select(x => new BlogListDto
            {
                BlogName = x.BlogName
            }).ToList();
            return (IEnumerable<Blogg>)Ok(blog);
        }

        [HttpPost(Name ="AddAsyncBlog")]
        [ProducesResponseType(typeof(BlogCreateDto),200)]
        public async Task<IActionResult> AddAsyncBlog([FromBody]BlogCreateDto model)
        {
            if (model!=null)
            {
				var blog = await _uow._blogRepository.AddAsync(new Blogg
				{
					BlogName = model.BlogName
				});
				 await _uow.Save();
				return Ok(model.BlogName);
			} else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteBlog/{id:int}")]
		[ProducesResponseType(typeof(BlogDeletedDto), 200)]
		public async Task<IActionResult> Remove([FromBody]BlogDeletedDto model)
        {
            var deletedBlog= await _uow._blogRepository.GetByIdAsync(model.BlogId.ToString());
            _uow._blogRepository.Remove(deletedBlog);
            await _uow.Save();
            return Ok(deletedBlog);
        }
    }
}
