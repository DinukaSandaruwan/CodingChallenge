using System;
using System.Collections.Generic;
using System.Text;

namespace Smartly.CodingChallenge
{

    public class TaxSlab
    {
        public int Id { get; private set; }
        public decimal MinAmount { get; private set; }
        public decimal MaxAmount { get; private set; }
        public decimal TaxRate { get; private set; }

        public TaxSlab(int Id, decimal minAmount, decimal maxAmount,decimal taxRate)
        {
            this.Id = Id;
            this.MinAmount = minAmount;
            this.MaxAmount = maxAmount;
            this.TaxRate = taxRate;
        }
    }


}
