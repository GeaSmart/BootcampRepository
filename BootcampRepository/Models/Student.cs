using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampRepository.Models
{
    public class Student : BaseEntity
    {        
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Calificacion { get; set; }
    }
}
