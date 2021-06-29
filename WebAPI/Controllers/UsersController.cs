using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            
            var result = _userService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }
           

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success==true)
            {
                return  Ok(result);
            }
            return BadRequest("geçersiz istek");
        }

        [HttpPost("Update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(user);
        }


        [HttpGet("email")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateprofile")]
        public IActionResult ProfileUpdate(UserForUpdateDto userForUpdateDto)
        {
            var result = _userService.EditProfil(userForUpdateDto.User, userForUpdateDto.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetClaims")]
        public IActionResult GetClaims(int id)
        {
           var result = _userService.GetClaims(id);
            if (result.Success==true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
