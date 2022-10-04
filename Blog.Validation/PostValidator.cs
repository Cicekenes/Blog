using Blog.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Validation
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.PostName).NotEmpty().WithMessage("Post adı boş olamaz!").MinimumLength(5).WithMessage("Blog adı 5 karakterden az olamaz!").MaximumLength(80).WithMessage("Blog adı 80 karakterden fazla olamaz!").NotNull().WithMessage("Post adı boş bırakılamaz!");

            RuleFor(x => x.PostTitle).NotEmpty().WithMessage("Başlık değeri giriniz!").NotNull().WithMessage("Başlık boş olamaz!").MinimumLength(5).WithMessage("5 karakterden az olamaz!").MaximumLength(50).WithMessage("50 karakterden fazla olamaz!");

            RuleFor(x => x.PostText).NotEmpty().WithMessage("Lütfen postunuzun içeriğini doldurunuz!").NotNull().WithMessage("Post alanını boş bırakılamaz!");
        }
    }
}
