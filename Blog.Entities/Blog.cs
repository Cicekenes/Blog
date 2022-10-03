using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Blog:Base
    {
        public Blog()
        {
            Categories = new HashSet<Category>();
        }
        public string BlogName { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
