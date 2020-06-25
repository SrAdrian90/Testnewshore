using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewShore.Models
{
    public class DetailsCustomerViewModel
    {
        [Display(Name = "Clientes de Newshore")]
        public string Name { get; set; }

        public bool Exist { get; set; }
    }
}
