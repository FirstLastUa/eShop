using eShop.Api.Contracts.Customer;
using eShop.Application.Customers.AddDeliveryAddress;
using eShop.Application.Customers.Create;
using eShop.Application.Customers.GetCustomer;
using eShop.Domain.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController(
        ILogger<CustomersController> logger,
        ISender sender) : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger = logger;
        private readonly ISender _sender = sender;

        [HttpGet(Name = "GetCustomer")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetCustomerQuery(id);

            Customer result = await _sender.Send(query);

            return result is null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost()]
        public async Task Create(CreateCustomerRequest request)
        {
            var command = new CreateCustomerCommand(request.FirstName, request.LastName, request.Email);

            await _sender.Send(command);
        }

        [HttpPost("AddDeliveryAddress")]
        public async Task AddDeliveryAddress(AddDeliveryAddressRequest request)
        {
            var command = new AddDeliveryAddressCommand(
                request.CustomerId,
                request.Street,
                request.City,
                request.State,
                request.Country,
                request.Zipcode
                );

            await _sender.Send(command);
        }
    }
}
