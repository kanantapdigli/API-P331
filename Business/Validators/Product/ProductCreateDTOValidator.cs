using Business.DTOs.Product.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Product
{
    public class ProductCreateDTOValidator : AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlıq daxil edilməlidir");

            RuleFor(x => x.Title)
                .MinimumLength(10)
                .WithMessage("Başlığın uzunluğu minimum 10 simvol olmalıdır");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıqlama daxil edilməlidir");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıqlamanın uzunluğu maksimum 500 simvol olmalıdır");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Məbləğ daxil edilməlidir");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Say düzgün daxil edilməyib");

            RuleFor(x => x.Photo)
                .Must(IsBase64String)
                .WithMessage("Göndərilən şəkil kontenti düzgün formatda deyil");

            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Tip düzgün seçilməyib");
        }

        private static bool IsBase64String(string photo)
        {
            byte[] output;
            try
            {
                output = Convert.FromBase64String(photo);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }
    }
}
