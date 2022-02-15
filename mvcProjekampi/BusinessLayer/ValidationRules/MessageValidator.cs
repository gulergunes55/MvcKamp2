using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Alıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3  karekter girişi yapınız!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en çok 100  karekter girişi yapınız!");
        }
    }
}
