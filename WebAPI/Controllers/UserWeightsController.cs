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
    public class UserWeightsController : ControllerBase
    {
        private readonly IUserWeightService _userWeightService;

        public UserWeightsController(IUserWeightService userWeightService)
        {
            _userWeightService = userWeightService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userWeightService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userWeightService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserWeight userWeight)
        {
            var result = _userWeightService.Add(userWeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserWeight userWeight)
        {
            var result = _userWeightService.Update(userWeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserWeight userWeight)
        {
            var result = _userWeightService.Delete(userWeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalluserweightlength")]
        public IActionResult GetAllRecipeLength()
        {
            var result = _userWeightService.GetAllUserWeightLength();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getalluserweightdetails")]
        public IActionResult GetAllUserWeightDetails()
        {
            var result = _userWeightService.GetAllUserWeightDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserweightdetailsbyid")]
        public IActionResult GetUserWeightDetailsById(int id)
        {
            var result = _userWeightService.GetUserWeightDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
