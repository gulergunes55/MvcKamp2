using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidatior:AbstractValidator<Contact>
    {
        public ContactValidatior()
        {

            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen ez az 3 karekter girişi yapınız!");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Lütfen 50 karekterden fazla giriş yapmayınız");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen 3 karekterden fazla giriş yapmayınız");
        }
    }
}
