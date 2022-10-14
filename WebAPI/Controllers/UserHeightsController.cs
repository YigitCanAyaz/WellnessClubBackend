using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHeightsController : ControllerBase
    {
        private readonly IUserHeightService _userHeightService;

        public UserHeightsController(IUserHeightService userHeightService)
        {
            _userHeightService = userHeightService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userHeightService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userHeightService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserHeight userHeight)
        {
            var result = _userHeightService.Add(userHeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserHeight userHeight)
        {
            var result = _userHeightService.Update(userHeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserHeight userHeight)
        {
            var result = _userHeightService.Delete(userHeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getalluserheightdetails")]
        public IActionResult GetAllUserHeightDetails()
        {
            var result = _userHeightService.GetAllUserHeightDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserheightdetailsbyid")]
        public IActionResult GetUserHeightDetailsById(int id)
        {
            var result = _userHeightService.GetUserHeightDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
