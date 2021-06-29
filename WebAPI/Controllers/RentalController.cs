using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllDetails")]
        public IActionResult GetDetails()
        {   
            var result = _rentalService.GetAllDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
