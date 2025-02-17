using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employee.Api.Dto;
using Employee.Api.Repo.Service;
using Employee.Api.Repo.Interface;
using System.Runtime.CompilerServices;
using Employee.Api.Model;

namespace Employee.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpController : ControllerBase
    {
        private readonly IRepository _repository;
         public EmpController(IRepository repository)
        {
           
           _repository=repository;

        }
         [HttpPost("Add")]
        public async Task<IActionResult> AddEmployee(EmpAddDto empAddDto)
        {
            var employeeData= await _repository.AddEmployee(empAddDto);
            return Ok(employeeData);
        }

        [HttpGet("getEmployees")]
        public async Task<IActionResult> GetALllEmployee()
        {
            var employees =await _repository.GetAllEmployee();
            return Ok(employees);
        }

        
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetEmplByID(int ID)
        {
            var employee=await _repository.GetEmployee(ID);
            if(employee==null)
            return NotFound();
          
            return Ok(employee);

        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetEmpById(int id)
        // {
        //     var employee1=(await _repository.GetEmployees(new[] {id})).FirstOrDefault(o=>o.Id==id);
        //     if(employee1==null)
        //     return NotFound();
        //     return Ok(employee1);
        

        // }

        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            var employees1=await _repository.GetEmployees(null);
            return Ok(employees1);

        }

        [HttpPut("{empId}")]
        public async Task<IActionResult> UpdateEmployee(int empId,EmpAddDto EmpAddDto)
        {
            //check whether an employee exixits with this id
            var existingEmp=(await _repository.GetEmployees(new[] {empId})).FirstOrDefault();

            if (existingEmp==null)
            return NotFound("sdff");
            await _repository.UpdateEmployee(empId,EmpAddDto);
            return NoContent();
           // return Ok();
        } 

        [HttpDelete("{empId}")]
         public async  Task<IActionResult> DeleteEmployee(int empId)
         {
            var existingEmp=(await _repository.GetEmployees(new[] {empId})).FirstOrDefault();
            if(existingEmp==null)
            return NotFound();
            await _repository.DeleteEmployee(empId);

            //Returns a 204 No Content response
            return NoContent();

         }

    }
}