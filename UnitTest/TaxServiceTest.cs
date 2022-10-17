using Smartly.CodingChallenge;
using Xunit;

namespace UnitTest
{
    public class TaxServiceTest
    {
        [Theory]
        [InlineData(14000,122.50)]
        [InlineData(0, 0)]
        [InlineData(60050, 919.58)]
        public void GetIncomeTax_retunIncomeTaxBaseOnAnnualSalary(decimal amount, decimal tax) 
        {
            var calTax = new TaxService().GetIncomeTax(amount);
            Assert.Equal(tax, calTax);
        } 
    }
}
