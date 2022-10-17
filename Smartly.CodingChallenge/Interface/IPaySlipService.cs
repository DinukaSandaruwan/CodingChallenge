using System.Collections.Generic;

namespace Smartly.CodingChallenge
{
    public interface IPaySlipService
    {
        public void Print(IEnumerable<PaySlip> paySlip);
        public List<PaySlip> GetPaySlip(IEnumerable<Employee> employee);
    }
}


