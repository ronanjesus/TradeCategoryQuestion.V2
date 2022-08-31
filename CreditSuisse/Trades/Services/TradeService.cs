using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Trades.Classes;

namespace Trades.Services
{
    public class TradeService
    {        
        public TradeService()
        {            
        }        

        public ITrade Categorize(double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate)
        {
            ITrade category = null;
            var typesCategory = GetClassesITrade();

            foreach (var item in typesCategory)
            {
                ITrade trade = (ITrade)Activator.CreateInstance(item);

                trade.Value = value;
                trade.ClientSector = clientSector;
                trade.NextPaymentDate = nextPaymentDate;
                trade.ReferenceDate = referenceDate;

                if (trade.CheckCategorized())
                {
                    category = trade;
                    break;
                }
            }

            return category;
        }

        private List<Type> GetClassesITrade()
        {
            var typesCategory = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => p.GetInterfaces()
                    .Where(c => c.Name.Contains("ITrade"))
                    .OrderBy(x => x.GetProperty("OrderPrecedence"))
                    .Any())
                .ToList();

            return typesCategory;
        }
    }
}
