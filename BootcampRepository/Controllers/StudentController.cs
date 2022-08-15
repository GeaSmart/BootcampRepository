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

        public StudentController(IRepository<Student> repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(new Student());
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(Student student)
        {
            if (ModelState.IsValid)
                await repository.CreateAsync(student);
            return Index();
        }
    }
}
