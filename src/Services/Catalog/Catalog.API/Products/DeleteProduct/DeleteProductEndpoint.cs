
namespace Catalog.API.Products.DeleteProduct;

//public record DeleteProductRequest(Guid id);

public record DeleteProductResponc(bool isSuccess);

public class DeleteProductEndpoint
    : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteProductCommand(id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteProductResponc>();
            if (response is null)
            {
                return Results.BadRequest(new { Message = "Failed to delete product" });
            }
            return Results.Ok(response);
        })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponc>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete a product");
    }
}
