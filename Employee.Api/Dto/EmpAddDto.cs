using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Api.Dto
{
    public class EmpAddDto
    {
        public string?  Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public int ManagerID { get; set; }
    }
}