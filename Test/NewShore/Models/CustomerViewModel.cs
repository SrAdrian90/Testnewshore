using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewShore.Models
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "El campo registro es obligatorio.")]
        public IFormFile RegisteredFile { get; set; }

        [Required(ErrorMessage = "El campo contenido es obligatorio.")]
        public IFormFile ContenFile { get; set; }
    }
}
