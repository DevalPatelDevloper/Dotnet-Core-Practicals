using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practical_17.Contract;
using practical_17.Models;
using practical_17.Repo;

namespace practical_17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo studentRepo;

        public StudentsController(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            var s = await studentRepo.GetAllAsync();
            return s;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await studentRepo.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {

            try
            {
                if (id == student.Id)
                {
                    if (ModelState.IsValid)
                    {
                        await studentRepo.UpdateAsync(student);
                    }
                }
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await studentRepo.Exist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                await studentRepo.AddAsync(student);
            }
            

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var stu = await studentRepo.Exist(id);
            if (stu == null)
            {
                return NotFound();
            }


            await studentRepo.DeleteAsync(id);

            return NoContent();
        }

    }
}
