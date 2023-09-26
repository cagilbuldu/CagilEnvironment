using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator:AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görev boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş geçilemez");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("Lütfen 50 karakterden az veri girişi yapın");
            RuleFor(x => x.PersonName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapın");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen 50 karakterden az veri girişi yapın");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapın");
        }
    }
}
