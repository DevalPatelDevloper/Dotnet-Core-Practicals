using practical_17.Contract;
using practical_17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_17.Repo
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
