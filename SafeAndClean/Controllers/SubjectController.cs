using Microsoft.AspNetCore.Mvc;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;

namespace SWP391_FindMentorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subService)
        {
            _subjectService = subService;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var rs = _subjectService.Get(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPost]
        public IActionResult Add([FromBody] SubjectAddModels model)
        {
            var rs = _subjectService.Add(model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] SubjectUpdateModels model)
        {
            var rs = _subjectService.Update(id, model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rs = _subjectService.Delete(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
    }

}
