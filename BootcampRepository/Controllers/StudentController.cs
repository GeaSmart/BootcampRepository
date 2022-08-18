using BootcampRepository.DTO;
using BootcampRepository.Models;
using BootcampRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dto = new StudentSearchDTO();
            if (TempData["myObject"] != null)
            {                
                dto = JsonConvert.DeserializeObject<StudentSearchDTO>((string)TempData["myObject"]);
            }
            else
            {
                dto.EstudiantesFiltrados = await repository.ReadAllAsync();
            }
            //if (dto.EstudiantesFiltrados == null)
               
            //var listadoBusqueda = new StudentSearchDTO() { EstudiantesFiltrados = listado };
            return View(dto);
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

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] StudentSearchDTO studentDTO)
        {
            var listado = new List<Student>();
            Expression<Func<Student, bool>> filter = m => m.Nombre.Contains(studentDTO.Estudiante.Nombre);

            if (string.IsNullOrEmpty(studentDTO.Estudiante.Nombre))
                listado = await repository.ReadAllAsync();
            else
                listado = await repository.ReadAllAsync(filter);
            
            var listadoBusqueda = new StudentSearchDTO() { Estudiante = studentDTO.Estudiante, EstudiantesFiltrados = listado };
            TempData["myObject"] = JsonConvert.SerializeObject(listadoBusqueda);

            return RedirectToAction("Index");
        }
    }
}
