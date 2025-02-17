using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Api.Model
{
    public class Emp
    {   
       [Key]
        public int Id { get; set; }
        public string?  Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        // public Guid mmm {get;set;}
        //set foreign key starts
        public int ManagerID { get; set; }
        [ForeignKey("ManagerID")]
        //navigation property
        public Manager Manager {get;set;}
       // set foreign key Ends
       
    }
       
}