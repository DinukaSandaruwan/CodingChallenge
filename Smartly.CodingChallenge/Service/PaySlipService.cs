using Smartly.CodingChallenge.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartly.CodingChallenge
{
    public class PaySlipService : IPaySlipService
    {
        private readonly ITaxService taxService;       
        public PaySlipService(ITaxService taxService)
        {
            this.taxService = taxService;             
        }

        public List<PaySlip> GetPaySlip(IEnumerable<Employee> employee)
        {
            var paySlip = new List<PaySlip>();
            foreach (var emp in employee)
            {
                var incomeTax = taxService.GetIncomeTax(emp.AnnualSalary);
                paySlip.Add(new PaySlip(emp, incomeTax));
            }
            return paySlip;
        } 
     
        public void Print(IEnumerable<PaySlip> paySlips) 
        {
            Console.WriteLine("");
            Console.WriteLine("Output(name, pay period, gross income, income tax, net income, super)");
            foreach (var paySlip in paySlips)
            {
                Console.WriteLine($"{paySlip.Name},{paySlip.PayPeriod}, {paySlip.GrossIncome.ToStringN2()}, {paySlip.IncomeTax.ToStringN2()}, {paySlip.NetIncome.ToStringN2()},{paySlip.Supper.ToStringN2()}");
            }
        }
    }
}
