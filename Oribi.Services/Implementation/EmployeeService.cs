using Oribi.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Oribi.Persistence.Data;
using System.Linq;


namespace Oribi.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext context;

        public EmployeeService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task CreateAsync(Employee newEmployee)
        {
            await context.Employees.AddAsync(newEmployee);
            await context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) =>
            context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task DeleteAsync(int employeeId)
        {
            var employee = GetById(employeeId);

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => context.Employees;
       

        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
