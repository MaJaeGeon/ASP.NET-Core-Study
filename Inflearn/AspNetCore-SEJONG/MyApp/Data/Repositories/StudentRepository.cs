using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private MyAppContext Context { get; set; }

        public StudentRepository(MyAppContext context)
        {
            Context = context;
        }

        public void AddStudent(Student student)
        {
            Context.Student.Add(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var result = Context.Student.ToList();

            return result;
        }

        public Student GetStudent(int id)
        {
            var result = Context.Student.Find(id);

            return result;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
