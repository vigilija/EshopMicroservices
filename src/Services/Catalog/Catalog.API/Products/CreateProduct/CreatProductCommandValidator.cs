
namespace Catalog.API.Products.CreateProduct
{
    public class CreatProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreatProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters");
            RuleFor(x => x.ImageFile)
                .NotEmpty().WithMessage("ImageFile is required")
                .MaximumLength(200).WithMessage("ImageFile must not exceed 200 characters");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
