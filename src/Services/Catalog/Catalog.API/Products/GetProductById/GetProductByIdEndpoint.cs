
namespace Catalog.API.Products.GetProductById;
//public record GetProductByIdRequest(Guid Id);
public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule

{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetProductByIdQuery(id);
            var result = await sender.Send(query);

            if (result == null)
            {
                return Results.NotFound(new { Message = "Product not found" });
            }

            var response = result.Adapt<GetProductByIdResponse>();           ;
            return Results.Ok(response);
        })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get product by ID")
            .WithDescription("Retrieves a product by its unique ID.");
    }
}
