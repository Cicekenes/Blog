using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dtos.BlogDtos
{
	public class BlogUpdateDto
	{
		[StringLength(50)]
		public string BlogName { get; set; }
	}
}
