using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Repositories;
using MyApp.Models;
using MyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherRepository TeacherRepository { get; set; }
        private IStudentRepository StudentRepository { get; set; }

        public HomeController(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            TeacherRepository = teacherRepository;
            StudentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var teachers = TeacherRepository.GetAllTeachers();

            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        [Authorize]
        public IActionResult Student()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() {Name = "A", Class="1"},
                new Teacher() {Name = "B", Class="2"},
                new Teacher() {Name = "C", Class="3"},
                new Teacher() {Name = "D", Class="4"},
            };

            StudentTeacherViewModel viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                StudentRepository.AddStudent(viewModel.Student);
                StudentRepository.Save();
            }

            return View();
        }
    }
}
