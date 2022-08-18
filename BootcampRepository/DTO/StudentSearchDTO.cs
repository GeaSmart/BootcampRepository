using BootcampRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampRepository.DTO
{
    public class StudentSearchDTO
    {
        public Student Estudiante { get; set; }
        public List<Student> EstudiantesFiltrados { get; set; }
    }
}
