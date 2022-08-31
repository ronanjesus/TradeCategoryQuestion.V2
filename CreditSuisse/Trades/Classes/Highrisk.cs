using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.Classes
{
    class Highrisk: ITrade
    {
        public int OrderPrecedence { get; set; } = 2;
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }

        public bool CheckCategorized()
        {
            return (ClientSector.ToUpper().Equals("PRIVATE") && Value > 1000000);
        }
    }
}
