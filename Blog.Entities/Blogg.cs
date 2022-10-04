using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Blogg:Base
    {
        public Blogg()
        {
            Categories = new HashSet<Category>();
        }
        [StringLength(50)]
        public string BlogName { get; set; }
        //Bir blogda birden fazla kategori olabilir.
        public ICollection<Category> Categories { get; set; }

    }
}
