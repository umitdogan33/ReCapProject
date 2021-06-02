using Business.Abstract;
using Entities.Concrete;
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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result= _CustomerService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        
        public IActionResult Add(Customer customers)
        {
            var result = _CustomerService.Add(customers);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
    }
}
