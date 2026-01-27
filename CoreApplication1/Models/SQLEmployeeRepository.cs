using Microsoft.EntityFrameworkCore;

namespace CoreApplication1.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;

        }

        public Employee AddEmployee(Employee employee)
        {
            _context.empTarget.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = _context.empTarget.Find(id);
            if(employee != null)
            {
                _context.empTarget.Remove(employee);
                _context.SaveChanges();
            }
            return employee;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.empTarget;

        }

        public Employee GetEmployee(int id)
        {
            return _context.empTarget.Find(id);
        }

        public Employee UpdateEmployee(Employee employeeC)
        {
            var employee = _context.empTarget.Attach(employeeC);
            employee.State = EntityState.Modified;
            _context.SaveChanges();

            return employeeC;
        }

    }
}
















































