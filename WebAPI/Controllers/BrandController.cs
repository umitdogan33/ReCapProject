using Business.Abstract;
using DataAccess.Abstract;
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
    public class BrandController : ControllerBase
    {
        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
           var result = _brandService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Brand brand) 
        {
            var result = _brandService.Delete(brand);
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(Brand brand) 
        {
            var result = _brandService.Update(brand);
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
