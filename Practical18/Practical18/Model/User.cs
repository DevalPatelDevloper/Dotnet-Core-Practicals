using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practical18.Model
{
    public class User :IdentityUser
    {
        [Required]
        public string fname { get; set; }
        [Required]
        public string lname { get; set; }

    }
}
