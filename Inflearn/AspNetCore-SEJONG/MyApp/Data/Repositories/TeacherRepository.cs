using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private MyAppContext Context { get; set; }
        public TeacherRepository(MyAppContext context)
        {
            Context = context;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            var result = Context.Teacher.ToList();

            return result;
        }

        public Teacher GetTeacher(int id)
        {
            var result = Context.Teacher.Find(id);

            return result;
        }
    }
}
