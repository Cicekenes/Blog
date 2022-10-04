using Blog.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Validation
{
    public class CommentValidator: AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Yorum yapılacak alan boş bırakılamaz!").MaximumLength(500).WithMessage("500 karakterden fazla yazılamaz!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş olamaz!").MaximumLength(50).WithMessage("İsim alanı 50 karakterden büyük olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Girilen değer bir mail adresi değildir!").NotEmpty().WithMessage("Mail alanı boş bırakılamaz!");
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Mesajınızı lütfen boş bırakmayınız").MaximumLength(500).WithMessage("500 karakterden fazla mesaj bırakamazsınız!");
        }
    }
}
