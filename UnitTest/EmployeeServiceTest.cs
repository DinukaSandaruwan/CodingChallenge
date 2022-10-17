using Microsoft.Extensions.Logging;
using Moq;
using Smartly.CodingChallenge;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class EmployeeServiceTest
    {
        [Fact]        
        public void GetEmployees_validateEmployeeObjectReturnFromDataSource() 
        {
            var mockiLog = new Mock<ILoggerFactory>();
            var mockEmp  = new Mock<IEmployeeService>();
            var mockData = new List<Employee>() { new Employee() { FirstName = "FirstName", LastName = "FirstName" } };           
            mockEmp.Setup(x => x.GetEmployees("")).Returns(mockData);
            var data = mockEmp.Object.GetEmployees("").ToList<Employee>();
            Assert.Equal(data[0].FirstName, mockData[0].FirstName);
            Assert.Equal(data[0].LastName, mockData[0].LastName);
        }
    }
}
