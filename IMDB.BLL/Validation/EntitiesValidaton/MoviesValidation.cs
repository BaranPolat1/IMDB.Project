using FluentValidation;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Validation.EntitiesValidaton
{
    public class MoviesValidation:AbstractValidator<MovieDTO>
    {
        public MoviesValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Film adı boş geçilemez!");
            RuleFor(x => x.Descreption).MaximumLength(255).WithMessage("Film açıklaması 255 karakteri geçemez!");
            
        }

    }
}
