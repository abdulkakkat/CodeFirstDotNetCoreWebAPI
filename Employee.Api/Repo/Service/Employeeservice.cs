using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Api.DataAccess;
using Employee.Api.Dto;
using Employee.Api.Model;
using Employee.Api.Repo.Interface;
using Microsoft.EntityFrameworkCore;


namespace Employee.Api.Repo.Service
{
    public class Employeeservice : IRepository
    {
        //  public readonly MyDbContext _myDbContext
        private  readonly MyDbContext _myDbContext;

        public Employeeservice(MyDbContext myDbContext)
        {
            _myDbContext=myDbContext;
        }

       public async Task<Emp> AddEmployee(EmpAddDto empAddDto)
        {
            var addEmployee=new Emp{
                Name=empAddDto.Name,
                Age=empAddDto.Age,
                Address=empAddDto.Address,
                ManagerID=empAddDto.ManagerID      
            };
            await _myDbContext.Employee.AddAsync(addEmployee);
            await  _myDbContext.SaveChangesAsync();
            return addEmployee;
           
        }

       public async Task<List<Emp>>GetAllEmployee()
        {

            var  employee=_myDbContext.Employee;
           return await employee.OrderBy(o=>o.Id).ToListAsync();
            
        }

       public async Task<Emp> GetEmployee(int id)
        {
            //var  employee= await _myDbContext.Employee.ToListAsync();
            var employee1= await _myDbContext.Employee.FirstOrDefaultAsync(x=>x.Id==id);
          
           return employee1;
           
        }


        public async  Task<IEnumerable<Emp>> GetEmployees(int[] ids)
        {
            var employee=_myDbContext.Employee.AsQueryable();
           //var employee=_myDbContext.Employee;
            
            //IQueryable<Emp> employee=_myDbContext.Employee;
            if(ids!=null && ids.Any())
            {
            employee=employee.Where(x=>ids.Contains(x.Id));
               

            }
            return await employee.ToListAsync();

        }

        public async  Task<Emp> UpdateEmployee(int empId,EmpAddDto empAddDto)
        {
            var employeeForchanges=await _myDbContext.Employee.SingleAsync(x=>x.Id==empId);
            employeeForchanges.Age=empAddDto.Age;
            employeeForchanges.Address=empAddDto.Address;
            employeeForchanges.Name=empAddDto.Name;

            _myDbContext.Employee.Update(employeeForchanges);
            await _myDbContext.SaveChangesAsync();
            return employeeForchanges;

        }
        public async  Task<bool> DeleteEmployee(int empId)
        {

            var employeeForDelete=await _myDbContext.Employee.SingleAsync(x=>x.Id==empId);
            _myDbContext.Employee.Remove(employeeForDelete);
            await _myDbContext.SaveChangesAsync();
            return true;
        }
    }
}