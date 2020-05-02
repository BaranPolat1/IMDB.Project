using FluentValidation;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Validation.EntitiesValidaton
{
    public class CategoryValidator:AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25).WithMessage("Kategori adı boş geçilemez ve 25 karakterden fazla olamaz!");
            RuleFor(x => x.Descreption).MaximumLength(150).WithMessage("Kategori açıklaması 150 karakterden fazla olamaz!");
        }
    }
}
