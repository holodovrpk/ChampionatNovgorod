using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champ.Data.Models
{
    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; } = "";
        public string error_code { get; set; } = "";
        public T? data { get; set; }

        
    }

}
