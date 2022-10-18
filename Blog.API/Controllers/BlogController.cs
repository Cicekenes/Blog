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

		[HttpGet(Name = nameof(GetAll))]
		[ProducesResponseType(typeof(BlogListDto), 200)]
		public IActionResult GetAll(bool tracking = true)
		{
			IEnumerable<BlogListDto> blog = _uow._blogRepository.GetAll(tracking).Select(x => new BlogListDto
			{
				BlogId = x.Id,
				BlogName = x.BlogName
			}).ToList();
			return Ok(blog);
		}

		[HttpPost(Name = "AddAsyncBlog")]
		[ProducesResponseType(typeof(BlogCreateDto), 200)]
		public async Task<IActionResult> AddAsyncBlog([FromBody] BlogCreateDto model)
		{
			//(_uow._blogRepository.GetAll().ToList().Any(x => x.BlogName.ToLower() != model.BlogName.ToLower()))

			if (model != null)
			{
				var blog = await _uow._blogRepository.AddAsync(new Blogg
				{
					BlogName = model.BlogName
				});
				await _uow.SaveAsync();
				return Ok(model.BlogName);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete("DeleteBlog")]
		[ProducesResponseType(typeof(BlogDeletedDto), 200)]
		public IActionResult Remove(BlogDeletedDto model)
		{
			var deletedBlog = _uow._blogRepository.GetById(model.BlogId);
			_uow._blogRepository.Remove(deletedBlog);
			_uow.Save();
			return Ok(deletedBlog);
		}
		[HttpPut("UpdateBlog/{id:Guid}")]
		[ProducesResponseType(typeof(BlogUpdateDto), 200)]
		public async Task<IActionResult> UpdateAsync([FromBody] BlogUpdateDto model)
		{
			var updatedBlog = await _uow._blogRepository.GetByIdAsync(model.BlogId);
			updatedBlog.BlogName = model.BlogName;
			_uow._blogRepository.Update(updatedBlog);
			await _uow.SaveAsync();
			return Ok(updatedBlog);
		}
	}
}
