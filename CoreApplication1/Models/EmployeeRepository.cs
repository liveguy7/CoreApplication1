
namespace CoreApplication1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public EmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                new Employee() {Id=1, Name="Mary", Department="HR", Email="mary@na.com" },
                new Employee() {Id=1, Name="John", Department="HR", Email="john@na.com" },
                new Employee() {Id=1, Name="Sam", Department="HR", Email="sam@na.com" }

            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e =>
                                                 e.Id == id);
        }


    }
}





