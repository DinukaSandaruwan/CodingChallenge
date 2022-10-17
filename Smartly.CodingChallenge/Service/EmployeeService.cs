using Microsoft.Extensions.Logging;
using Smartly.CodingChallenge.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.CodingChallenge
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EmployeeService>();
        }

        public IEnumerable<Employee> GetEmployees(string filePath)
        {
            if (!File.Exists(filePath))
            {
                _logger.LogError($"Invalid File Path {filePath}");
                return new List<Employee>();
            }
            //pending to validate input data quality
            // query CSV file through LINQ
            var data = (from line in File.ReadAllLines(filePath).Skip(1)
                        let columns = line.Split(',')
                        select new Employee
                        {
                            FirstName = columns[0],
                            LastName = columns[1],
                            AnnualSalary = Convert.ToDecimal(columns[2]),
                            SuperRate = columns[3],
                            PayPeriod = columns[4]
                        }).ToList();

            return data;

        }

        public void Print(IEnumerable<Employee> empList)
        {
            Console.WriteLine("");
            Console.WriteLine("Input (First Name, Last Name, Annual Salary, Super Rate, Pay Period)");
            foreach (var emp in empList)
            {
                Console.WriteLine($"{emp.FirstName},{emp.LastName}, {emp.AnnualSalary}, {emp.SuperRate}, {emp.PayPeriod}");
            }

        }
    }
}
