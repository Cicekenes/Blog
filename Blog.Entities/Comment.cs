using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Comment:Base
    {
        [StringLength(500)]
        public string CommentText { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //İletişim kurmak adına mesaj bırakmak ister mi?
        [StringLength(500)]
        public string ContactMessage { get; set; }
        //Bir kullanıcı birden fazla yorum yapabilir.
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public User Users { get; set; }
        //Bir postta birden fazla yorum olabilir
        [ForeignKey("Posts")]
        public Guid PostId { get; set; }
        public Post Posts { get; set; }

    }
}
