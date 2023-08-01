using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Desc1).NotEmpty().WithMessage("Açıklama 1 boş geçilemez");
            RuleFor(x => x.Desc2).NotEmpty().WithMessage("Açıklama 2 boş geçilemez");
            RuleFor(x => x.Desc3).NotEmpty().WithMessage("Açıklama 3 boş geçilemez");
            RuleFor(x => x.Desc4).NotEmpty().WithMessage("Açıklama 4 boş geçilemez");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez");
            RuleFor(x => x.Desc1).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakterlik veri girişi yapın");
            RuleFor(x => x.Desc2).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakterlik veri girişi yapın");
            RuleFor(x => x.Desc3).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakterlik veri girişi yapın");
            RuleFor(x => x.Desc4).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakterlik veri girişi yapın");


        }
    }
}
