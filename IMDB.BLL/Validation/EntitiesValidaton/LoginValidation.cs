using FluentValidation;
using IMDB.Infrastructure.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Validation.EntitiesValidaton
{
   public class LoginValidation:AbstractValidator<LoginVM>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Lütfen mail adresinizi kontrol ediniz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifrenizi kontrol ediniz!");
        }
    }
}
