using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_s.Reponses
{
     public class ApiResponseDTO<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }

    }
}
