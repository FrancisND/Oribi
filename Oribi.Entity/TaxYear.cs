using System;
using System.Collections.Generic;
using System.Text;

namespace Oribi.Entity
{
    public class TaxYear
    {
        public int Id { get; set; }
        public string YearOfTax { get; set; }

        // 1 to Many relationship
        public IEnumerable<PaymentRecord> PaymentRecords { get; set; }

    }
}
