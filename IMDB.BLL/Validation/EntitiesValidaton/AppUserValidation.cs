using FluentValidation;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Validation.EntitiesValidaton
{
   public class AppUserValidation:AbstractValidator<UserDTO>
    {
        public AppUserValidation()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email alanı boş geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).WithMessage("Kullanıcı adınız 3 kelimeden az olamaz!");
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).WithMessage("Adınız 3 kelimeden az olamaz!");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).WithMessage("Soyadınız 3 kelimeden az olamaz!");
        }
    }
}
