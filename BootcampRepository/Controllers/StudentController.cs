using BootcampRepository.Models;
using BootcampRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampRepository.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> repository;

        [BindProperty]
        public Student student { get; set; }

        public StudentController(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] Student student)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
