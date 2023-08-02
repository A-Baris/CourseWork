using CA_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_School.Repositories
{
    internal interface IStudentRepository
    {
        List<Student> GetStudents();
        string AddStudent(Student student);
        string UpdateStudent(Student student);
        string DeleteStudent(int sId);
    }
}
