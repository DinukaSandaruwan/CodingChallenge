using Microsoft.Extensions.Logging;
using Smartly.CodingChallenge.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartly.CodingChallenge
{
    public class TaxService : ITaxService
    {
        public List<TaxSlab> GetTaxSlab()
        {
            return new List<TaxSlab>()
            {
            new TaxSlab(1,0,14000,10.5M),
            new TaxSlab(2,14000,48000,17.5M),
            new TaxSlab(2,48000,70000,30.0M),
            new TaxSlab(2,70000,180000,33.0M),
            new TaxSlab(2,180000,Decimal.MaxValue,39.0M),
            };
        }

        public decimal GetIncomeTax(decimal amount)
        {
            var tax = GetTaxSlab();
            decimal taxAmount = 0;
            bool hasTax = true;
            int i = 0;
            while (hasTax)
            {
                if (amount > tax[i].MaxAmount)
                {
                    taxAmount += (tax[i].MaxAmount - tax[i].MinAmount) * tax[i].TaxRate / 100;
                }
                else
                {
                    taxAmount += (amount - tax[i].MinAmount) * tax[i].TaxRate / 100;
                    hasTax = false;
                }
                i++;
            }
            return (taxAmount/12).Round();
        }        
    }
}

