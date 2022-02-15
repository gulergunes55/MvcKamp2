﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior : AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soy adını boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
            
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen ez az 3  karekter girişi yapınız!");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen 50 karekterden fazla giriş yapmayınız");
        }
    }
}
