
namespace CoreApplication1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public EmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                new Employee() {Id=1, Name="Mary", Department=Dept.HR, Email="mary@na.com" },
                new Employee() {Id=2, Name="John", Department=Dept.HR, Email="john@na.com" },
                new Employee() {Id=3, Name="Sam", Department=Dept.HR, Email="sam@na.com" }

            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e =>
                                                 e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;

        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(e =>
                         e.Id) + 1;
            _employeeList.Add(employee);

            return employee;

        }

        public Employee UpdateEmployee(Employee employeeC)
        {
            Employee employee = _employeeList.FirstOrDefault(e =>
                                                      e.Id == employeeC.Id);
            if(employee != null)
            {
                employee.Name = employeeC.Name;
                employee.Email = employeeC.Email;
                employee.Department = employeeC.Department;
            }
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e =>
                                                     e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);

            }
            return employee;
        }


    }
}
















