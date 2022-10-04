using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Category : Base
    {
        public Category()
        {
            Posts=new HashSet<Post>();
        }
        [StringLength(40)]
        public string CategoryName { get; set; }
        //Bir category'de birden fazla post olabilir
        public ICollection<Post> Posts { get; set; }
        //Her kategori bir blog'a bağlı olmak zorunda
        [ForeignKey("Blogs")]
        public int BlogId { get; set; }
        public Blogg Blogs { get; set; }

    }
}
