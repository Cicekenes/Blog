using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Post:Base
    {
        public Post()
        {
            Comments=new HashSet<Comment>();
        }
        [StringLength(80,MinimumLength =5)]
        public string PostName { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        [ForeignKey("Categories")]
        //Her post bir kategoriye bağlıdır
        public Guid CategoryId { get; set; }
        public Category Categories { get; set; }
        //Bir postta birden fazla yorum olabilir
        public ICollection<Comment> Comments { get; set; }
    }
}
