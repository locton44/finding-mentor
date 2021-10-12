using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP391_FindMentorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var rs = _courseService.Get(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
        [HttpGet("Filter")]
        public IActionResult Filter(string name)
        {
            var rs = _courseService.Search(name);
            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseAddModels model)
        {
            var rs = _courseService.Add(model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CourseUpdateModels model)
        {
            var rs = _courseService.Update(id, model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rs = _courseService.Delete(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
    }
}

