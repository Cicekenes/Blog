using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int WhoCreated { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int WhoUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public Base()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
            if (WhoCreated == null || WhoUpdated == null)
            {
                WhoCreated = 99999;
                WhoUpdated = 99999;
            }

        }
    }
}
