using EtkinlikAPI.Models.DTO;
using FluentValidation;

namespace EtkinlikAPI.Models.Validations
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name alani bos gecilemez")
                .MinimumLength(2).WithMessage("2 karakterden kucuk bir kategori adi olamaz");
        }
    }
}
