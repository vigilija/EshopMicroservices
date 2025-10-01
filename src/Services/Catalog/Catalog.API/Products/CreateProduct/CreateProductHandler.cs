
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //var validationResult = await validator.ValidateAsync(command, cancellationToken);
            //var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            //if (errors.Any())
            //{
            //    throw new ValidationException(errors.FirstOrDefault());
            //}

            logger.LogInformation("Handling CreateProductCommand {@Command}", command);
            var prodduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            session.Store(prodduct);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(prodduct.Id);
        }
    }
}
