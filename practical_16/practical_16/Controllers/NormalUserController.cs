using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practical_16.Constant;
using practical_16.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_16.Controllers
{
    [Authorize(Roles = Role.User)]
    public class NormalUserController : Controller
    {
        private readonly IStudentRepo studentRepo;

        public NormalUserController(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await studentRepo.GetAllAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await studentRepo.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
