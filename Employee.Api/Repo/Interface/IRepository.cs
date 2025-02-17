using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Api.Model;
using Employee.Api.Dto;

namespace Employee.Api.Repo.Interface
{
    public interface IRepository
    {
        Task<List<Emp>> GetAllEmployee();
        Task<Emp> GetEmployee(int id);
        // alternative method to get employee data  by id/all
         Task<IEnumerable<Emp>> GetEmployees(int[] ids);
       // end
        Task<Emp> AddEmployee(EmpAddDto empDto);

        Task<Emp> UpdateEmployee(int empId,EmpAddDto empAddDto);

         Task<bool> DeleteEmployee(int empId);

        

    }
}