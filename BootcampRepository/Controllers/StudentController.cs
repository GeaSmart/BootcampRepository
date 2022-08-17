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

        //[BindProperty]
        //public Student student { get; set; }

        public StudentController(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listado = await repository.ReadAllAsync();
            return View(listado);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            var student = await repository.ReadOneAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit([FromForm] Student student)
        {
            if (ModelState.IsValid)
            {
                if(student.Id == 0)                
                    await repository.CreateAsync(student);                
                else                
                    await repository.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
