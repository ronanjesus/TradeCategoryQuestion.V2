using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.Classes
{
    class Mediumrisk : ITrade
    {
        public int OrderPrecedence { get; set; } = 3;
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }        

        public bool CheckCategorized()
        {
            return (ClientSector.ToUpper().Equals("PUBLIC") && Value > 1000000);
        }
    }
}
