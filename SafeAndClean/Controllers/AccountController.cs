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

namespace SafeAndClean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Login(UserAuthModel model)
        {
            var result = await _accountService.Login(model);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost("AdminAuth")]
        public async Task<IActionResult> LoginAdmin (AdminLoginModel model)
        {
            var result = await _accountService.LoginAdmin(model);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }


        /*  [HttpPost("RegisterMentor")]

          public async Task<IActionResult> CustomerRegister(UserRegisterModel model)
          {
              var result = await _accountService.Register(model, ConstUserRoles.MENTOR);
              if (result.Success) return Ok(result.Data);
              return BadRequest(result.ErrorMessage);
          }

          [HttpPost("RegisterStudent")]

          public async Task<IActionResult> EmployeeRegister(UserRegisterModel model)
          {
              var result = await _accountService.Register(model, ConstUserRoles.STUDENT);
              if (result.Success) return Ok(result.Data);
              return BadRequest(result.ErrorMessage);
          }



          [HttpPost("Register")]
        /*  [Authorize(AuthenticationSchemes = "Bearer", Roles = ConstUserRoles.ADMIN)]*/
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserAuthModel model)
        {
            var result = await _accountService.Register(model, ConstUserRoles.USER);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}
