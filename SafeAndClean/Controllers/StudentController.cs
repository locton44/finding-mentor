using Data.StaticData;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP391_FindStudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _StudentService;

        public StudentController(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = ConstUserRoles.ALL)]
        public IActionResult Get(Guid? id)
        {
            var result = _StudentService.Get(id);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = ConstUserRoles.ALL)]
        public IActionResult Create([FromBody] StudentAddModel model)
        {
            var result = _StudentService.Create(model);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = ConstUserRoles.ALL)]
        public IActionResult Update(Guid id, [FromBody] StudentUpdateModel model)
        {
            var result = _StudentService.Update(id, model);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = ConstUserRoles.ALL)]
        public IActionResult Delete(Guid id)
        {
            var result = _StudentService.Delete(id);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
    }
}
