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
    public class CollaborationsController : ControllerBase
    {
        private readonly ICollaborationService _collaborationService;

        public CollaborationsController(ICollaborationService collaborationService)
        {
            _collaborationService = collaborationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _collaborationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalleventlength")]
        public IActionResult GetAllCollaborationLength()
        {
            var result = _collaborationService.GetAllCollaborationLength();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _collaborationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Collaboration collaboration)
        {
            var result = _collaborationService.Add(collaboration);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Collaboration collaboration)
        {
            var result = _collaborationService.Update(collaboration);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Collaboration collaboration)
        {
            var result = _collaborationService.Delete(collaboration);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
