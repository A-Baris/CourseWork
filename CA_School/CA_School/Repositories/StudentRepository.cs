using CA_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_School.Repositories
{
    internal class StudentRepository:IStudentRepository
    {

        SchoolDbContext db = new SchoolDbContext();
        public string AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return "Added is succesful";
        }

        public string DeleteStudent(int sId)
        {
            
                
                var student = db.Students.Find(sId);
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                    return "Deleting is succesful";


                }
                else
                {

                    Console.WriteLine("Database does not contain Student ID");
                    return "Deleting is failure";
                    
                }
            
            
        }

        public List<Student> GetStudents()
        {
            var studentList = db.Students.ToList();
            return studentList;
        }

        public string UpdateStudent(Student student)
        {
            db.Update(student);
            db.SaveChanges();
            return "Updated is succesful";
        }
    }
}

