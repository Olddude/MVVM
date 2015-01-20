using System.Collections.Generic;
using NewMVVM.Model;

namespace NewMVVM.DataAccess
{
    public class EmployeeRepository
    {
        readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            if (_employees == null)
            {
                _employees = new List<Employee>();
            }
            _employees.Add(Employee.CreateEmployee("John", "Smith"));
            _employees.Add(Employee.CreateEmployee("Jill", "Jones"));
            _employees.Add(Employee.CreateEmployee("Catht", "Morts"));
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(_employees);
        }
    }
}
