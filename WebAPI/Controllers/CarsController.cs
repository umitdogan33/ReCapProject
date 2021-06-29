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
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carservice.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var result = _carservice.GetById(Id);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByColorId")]
        public IActionResult GetByColorId(int Id)
        {
            var result = _carservice.GetByColorId(Id);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByBrandIdAndColorId")]
        public IActionResult GetByBrandIdAndColorId(int brandId,int ColorId)
        {
            var result = _carservice.GetByBrandIdAndColorId(brandId,ColorId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllDetails")]

        public IActionResult GetCarDetails() 
        {
            var result = _carservice.GetAllDetails();
            if(result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]

        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(car);
        }

        [HttpGet("GetByBrandId")]
        public IActionResult GetByBrandId(int BrandId)
        {
            var result = _carservice.GetByBrandId(BrandId);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }


        [HttpGet("GetCarsDetailByCarId")]
        public IActionResult GetCarsByCarId(int Id) 
        {
            var result = _carservice.GetDetailsByCarId(Id);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]

        public IActionResult Update(Car car)
        {
            var result = _carservice.Update(car);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(car);
        }

        [HttpGet("GetCarByCarId")]
        public IActionResult GetCarByCarId(int Id)
        {
            var result = _carservice.GetCarsByCarId(Id);
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
    }

