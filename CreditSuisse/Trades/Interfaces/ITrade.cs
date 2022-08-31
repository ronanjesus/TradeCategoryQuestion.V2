using System;

namespace Trades
{
    public interface ITrade
    {
        public int OrderPrecedence { get; set; }
        double Value { get; set; } 
        string ClientSector { get; set; } 
        DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; }
        public bool CheckCategorized();
    }
}
