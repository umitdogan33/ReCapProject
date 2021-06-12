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
        IBrandService _brandDal;

        public BrandController(IBrandService brandDal)
        {
            _brandDal = brandDal;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
           var result = _brandDal.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandDal.Add(brand);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
