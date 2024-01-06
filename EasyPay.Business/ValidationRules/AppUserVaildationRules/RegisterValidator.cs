using EasyPay.DTO.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Business.ValidationRules.AppUserVaildationRules
{
    public class RegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("Username length must be less than 30 character");
            RuleFor(x => x.Username).MinimumLength(2).WithMessage("Username length must be more than 2 character");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter valid email adress");

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Password does not match");
        }
    }
}
