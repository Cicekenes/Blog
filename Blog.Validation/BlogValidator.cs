using Blog.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Validation
{
    public class BlogValidator: AbstractValidator<Blogg>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.BlogName).NotEmpty().WithMessage("Blog adı boş bırakılamaz").NotNull().WithMessage("Blog boş olamaz").MaximumLength(50).WithMessage("Blog adı 50 karakterden fazla olamaz!"); 
        }
    }
}
