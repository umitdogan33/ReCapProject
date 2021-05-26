using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _CustomerService;

        public CustomersController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result= _CustomerService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
