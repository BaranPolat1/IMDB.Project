using FluentValidation;
using IMDB.Infrastructure.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Validation.EntitiesValidaton
{
   public class RegisterValidation:AbstractValidator<RegisterVM>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName kısmı boş geçilemez!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName kısmı boş geçilemez!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen mail adresinizi kontrol ediniz!");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Lütfen parolanızı en az 8 karakter olacak şekilde giriniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName kısmı boş geçilemez!");
        }
    }
}
