using eShop.Api.Contracts.Product;
using eShop.Application.Products.Create;
using eShop.Application.Products.GetProduct;
using eShop.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(
        ILogger<ProductsController> logger,
        ISender sender) : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger = logger;
        private readonly ISender _sender = sender;

        [HttpGet(Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProductQuery(id);

            Product result = await _sender.Send(query);

            return result is null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost()]
        public async Task Create(CreateProductRequest request)
        {
            _logger.LogInformation("Creating a product {name}", request.Name);

            var command = new CreateProductCommand(
                request.Name, request.Description, new Money(request.Currency, request.Value), request.IsAvailable);

            var product = await _sender.Send(command);
        }
    }
}
