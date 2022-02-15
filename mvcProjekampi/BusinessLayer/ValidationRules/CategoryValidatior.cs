using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen ez az 3 karekter girişi yapınız!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karekterden fazla giriş yapmayınız");
        }

    }
}
