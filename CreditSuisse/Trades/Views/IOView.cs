using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Trades.Services;

namespace Trades.Views
{
    public class IOView
    {
        public DateTime ReadReferenceDate()
        {
            Console.WriteLine("Input the reference date (format mm/dd/aaaa) :");
            return DateTime.Parse(Console.ReadLine(), new CultureInfo("en-US"));
        }

        public int ReadNumberOfTrades()
        {            
            Console.WriteLine("Input number of trade(s):");
            int.TryParse(Console.ReadLine(), out var numeroTrades);
            return numeroTrades;
        }

        public List<ITrade> ReadPortfolioTrades(DateTime referenceDate, int numeroTrades)
        {
            double value;
            string clientSector;
            DateTime nextPaymentDate;
            ITrade trade;
            TradeService tradeService = new TradeService();            
            List<ITrade> portfolio = new List<ITrade>();

            Console.WriteLine("Input the " + numeroTrades.ToString() + " trade(s) in the pattern explained below");
            Console.WriteLine("Input trade amount, client’s sector and date of next pending payment. (in this order separated by a space)");
            for (int i = 1; i <= numeroTrades; i++)
            {
                string[] tradeInput = Console.ReadLine().Split(' ');
                value = double.Parse(tradeInput[0]);
                clientSector = tradeInput[1];
                nextPaymentDate = DateTime.Parse(tradeInput[2], new CultureInfo("en-US"));

                trade = tradeService.Categorize(value, clientSector, nextPaymentDate, referenceDate);
                portfolio.Add(trade);
            }

            return portfolio;
        }

        public void PrintTradesCategory(List<ITrade> portfolio)
        {
            Console.WriteLine("");
            Console.WriteLine("Categorization of trades:");
            foreach (var item in portfolio)                
                Console.WriteLine(item.GetType().Name);            

            Console.ReadLine();
        }
    }
}
