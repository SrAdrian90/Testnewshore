using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewShore.Request
{
    public class ResultFilterRequest
    {
        [Required]
        public byte[] RegisterArray { get; set; }

        [Required]
        public byte[] ContenArray { get; set; }
    }
}
