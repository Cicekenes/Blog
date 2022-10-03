using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Post:Base
    {
        public string PostName { get; set; }
        public string PostTitles { get; set; }
        public string PostText { get; set; }
    }
}
