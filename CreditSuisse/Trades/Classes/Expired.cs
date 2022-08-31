using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.Classes
{
    class Expired: ITrade
    {
        public int OrderPrecedence { get; set; } = 1;
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }

        public bool CheckCategorized()
        {            
            return (NextPaymentDate.AddDays(30) < ReferenceDate);
        }        
    }
}
