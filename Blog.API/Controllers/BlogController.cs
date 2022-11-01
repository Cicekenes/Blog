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
			IEnumerable<BlogListDto> blog = _uow._blogRepository.GetAll(tracking).Where(x=>x.IsActive==true && x.IsDeleted==false).Select(x => new BlogListDto
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

			if (model != null && !(_uow._blogRepository.GetAll().Any(x=>x.BlogName==model.BlogName)))
			{
				var blog = await _uow._blogRepository.AddAsync(new Blogg
				{
					BlogName = model.BlogName.Trim()
				});
				await _uow.SaveAsync();
				return Ok($"{model.BlogName} adlı kayıt başarılı olarak eklenmiştir!");
			}
			else
			{
				return BadRequest($"{model.BlogName} adına sahip başka bir blog var yada değeriniz boş!");
			}
		}

		[HttpDelete("DeleteBlog")]
		[ProducesResponseType(typeof(BlogDeletedDto), 200)]
		public IActionResult Remove(BlogDeletedDto model)
		{
			var deletedBlog = _uow._blogRepository.GetById(model.BlogId);
			if (deletedBlog!=null && _uow._blogRepository.GetAll().Any(x=>x.Id==model.BlogId))
			{
				_uow._blogRepository.Remove(deletedBlog);
				_uow.Save();
				return Ok($"{deletedBlog.BlogName} adlı blog silinmiştir!");
			} else
			{
				return BadRequest($"{deletedBlog.BlogName} Blog Silinemedi veya silinemez");
			}
			
		}
		[HttpPut("UpdateBlog/{id:Guid}")]
		[ProducesResponseType(typeof(BlogUpdateDto), 200)]
		public async Task<IActionResult> UpdateAsync([FromBody] BlogUpdateDto model)
		{
			var updatedBlog = await _uow._blogRepository.GetByIdAsync(model.BlogId);
			updatedBlog.BlogName = model.BlogName;
			if (updatedBlog!=null && !(_uow._blogRepository.GetAll().Any(x => x.BlogName == model.BlogName)))
			{
				_uow._blogRepository.Update(updatedBlog);
				await _uow.SaveAsync();
				return Ok($"{updatedBlog.BlogName} Başarılı bir şekilde güncellenmiştir!");
			} else
			{
				return BadRequest($"{model.BlogName} adına sahip bir blog var yada böyle bir blog yok");
			}
			
		}
	}
}
