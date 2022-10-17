using Microsoft.Extensions.Logging;
using Moq;
using Smartly.CodingChallenge;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class PaySlipServiceTest
    {
        [Fact]       
        public void GetPaySlip_returnEmployeePaySlip()  
        {
            var mockiLog = new Mock<ILoggerFactory>();
            var calTax = new TaxService();
            var payslipService = new PaySlipService(new TaxService());
            var mockData = new List<Employee>() { new Employee() {
                FirstName = "FirstName",
                LastName = "LastName",
                AnnualSalary = 0,
                PayPeriod ="March",
                SuperRate ="9%"
            } };
            var data = payslipService.GetPaySlip(mockData);
            Assert.NotNull(data);
            Assert.Equal(data[0].Name, $"{mockData[0].FirstName} {mockData[0].LastName}");
            Assert.Equal(0,data[0].NetIncome);
            Assert.Equal($"01 March - 31 March", data[0].PayPeriod);
        }

        
    }
}
