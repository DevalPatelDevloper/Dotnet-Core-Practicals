
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using practical_18.Context;
using practical_18.Model;
using Practical18.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace practical_18.Repo
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepo(UserManager<User> userManager, SignInManager<User> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SignUpAsync(SignUp signUp)
        {
            var user = new User()
            {
                fname = signUp.fName,
                lname = signUp.lName,
                Email = signUp.Email,
                UserName = signUp.Email
            };
            return await _userManager.CreateAsync(user, signUp.Password);
        }
        public async Task<string> LoginAsync(SignIn signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, false, false);
            if (result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,signIn.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var tocken = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(tocken);
        }
    }
}

