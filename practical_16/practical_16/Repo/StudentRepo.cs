using practical_16.Contract;
using practical_16.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_16.Repo
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
