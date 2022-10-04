﻿using Blog.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Validation
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz!").NotNull().WithMessage("Kategori adı boş olamaz!").MaximumLength(40).WithMessage("Kategori 40 karakterden büyük olamaz!");
        }
    }
}
