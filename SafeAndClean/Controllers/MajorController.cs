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
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var rs = _majorService.Get(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPost]
        public IActionResult Add([FromBody] MajorAddModel model)
        {
            var rs = _majorService.Add(model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] MajorUpdateModel model)
        {
            var rs = _majorService.Update(id, model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rs = _majorService.Delete(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
    }
}
