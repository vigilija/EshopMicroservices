
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DelegateProductResult>;

public record DelegateProductResult(bool IsSuccess);

internal class DeleteProductCommandHandler
    (IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DelegateProductResult>
{
    public async Task<DelegateProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommand.Handle called with {@Command}", command);

        session.Delete<Product>(command);

        await session.SaveChangesAsync(cancellationToken);

        return new DelegateProductResult(true);

    }
}
