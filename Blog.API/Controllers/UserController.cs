using Blog.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUnitOfWork _uow;

		public UserController(IUnitOfWork ouw)
		{
			_uow = ouw;
		}

		
	}
}
