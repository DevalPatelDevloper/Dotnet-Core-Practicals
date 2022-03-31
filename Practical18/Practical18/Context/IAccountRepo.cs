using Microsoft.AspNetCore.Identity;
using practical_18.Model;
using Practical18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_18.Context
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUpAsync(SignUp signUp);
        Task<string> LoginAsync(SignIn signIn);
    }
}
