using Blog.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Validation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.Name).NotNull().WithMessage("İsim alanı boş olamaz!").NotEmpty().WithMessage("Lütfen isminizi giriniz").MinimumLength(2).WithMessage("İsminiz 2 karakterden küçük olamaz").MaximumLength(25).WithMessage("İsminiz 25 karakterden çok olamaz");

            RuleFor(x=>x.Surname).NotNull().WithMessage("Soyadınız boş olamaz!").NotEmpty().WithMessage("Lütfen soyadınızı giriniz!").MinimumLength(2).WithMessage("İsminiz 2 karakterden küçük olamaz").MaximumLength(25).WithMessage("İsminiz 25 karakterden çok olamaz");

            RuleFor(x => x.Birthday).NotNull().WithMessage("Doğum günü boş olamaz!").NotEmpty().WithMessage("Doğum gününüzü lütfen giriniz!").Must(BeAValidDate).WithMessage("Doğum gününüzü lütfen doğru şekilde giriniz!");

            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("E-mail adresinizi boş bırakamazsınız!").NotNull().WithMessage("E-mail adresi zorunlu alandır!").MinimumLength(11).WithMessage("E-mail en az 11 karakter olmak zorundadır!").MaximumLength(100).WithMessage("100 karakterden fazla mail adresi girilemez!");

            RuleFor(x => x.Username).NotNull().WithMessage("Kullanıcı adı zorunlu alandır! Boş Bırakılamaz!").NotEmpty().WithMessage("Kullanıcı adı gönderilemez").MinimumLength(5).WithMessage("Kullanıcı adınız 5 karakterden küçük olamaz").MaximumLength(25).WithMessage("Kullanıcı adınız 30 karakterden çok olamaz"); ;
        }

        private bool BeAValidDate(DateTime time)
        {
            return !time.Equals(default(DateTime)).Equals(DateTime.Now<time);
        }
    }
}
