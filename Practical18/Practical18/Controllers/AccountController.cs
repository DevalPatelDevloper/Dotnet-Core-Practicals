using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practical_18.Context;
using practical_18.Model;
using Practical18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_18.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
            var result = await _accountRepo.SignUpAsync(signUp);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignIn signIn)
        {
            var result = await _accountRepo.LoginAsync(signIn);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
