using Smartly.CodingChallenge.Extension;
using System;
using System.Globalization;

namespace Smartly.CodingChallenge
{
    public class PaySlip
    { 
        public string Name { get; private set; }
        public string PayPeriod { get; private set; }
        public decimal GrossIncome { get; private set; }
        public decimal IncomeTax { get; private set; }
        public decimal NetIncome { get; private set; }
        public decimal Supper { get; protected set; }

        public PaySlip(Employee employee, decimal incomeTax)
        {
            this.Name = $"{employee.FirstName} {employee.LastName}";
            this.PayPeriod = employee.PayPeriod.PayPeriodStartEnd();
            this.GrossIncome = (employee.AnnualSalary / 12).Round();
            this.Supper = (this.GrossIncome * employee.SuperRate.PrecentValue()/100).Round();
            this.IncomeTax = incomeTax;
            this.NetIncome = this.GrossIncome - incomeTax;
        }

    }


}
