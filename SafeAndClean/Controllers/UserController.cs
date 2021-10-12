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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var rs = _userService.Get(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rs = _userService.Delete(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
    }
}
