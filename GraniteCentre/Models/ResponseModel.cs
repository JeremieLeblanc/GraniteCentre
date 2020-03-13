using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteCentre.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
