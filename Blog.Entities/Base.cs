using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WhoCreated { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int WhoUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime BannedTime { get; set; }
        public int Role { get; set; }
    }
}
