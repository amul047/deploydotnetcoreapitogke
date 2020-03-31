using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleApi.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerTypesController : ControllerBase
    {

        private readonly ILogger<CustomerTypesController> _logger;

        public CustomerTypesController(ILogger<CustomerTypesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CustomerType> Get()
        {
            _logger.LogInformation("Getting customer types for fibre v2");
            return new List<CustomerType>
            {
                new CustomerType{Code = "Residential", DisplayName = "Residential"},
                new CustomerType{Code = "Education", DisplayName = "Education"},
                new CustomerType{Code = "Business", DisplayName = "Business"},
                new CustomerType{Code = "SM", DisplayName = "SmallBusiness"}
            };
        }
    }
}
