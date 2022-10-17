using System.Collections.Generic;

namespace Smartly.CodingChallenge
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetEmployees(string filePath);
        void Print(IEnumerable<Employee> empList);
    }
}
