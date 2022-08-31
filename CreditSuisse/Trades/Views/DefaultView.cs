using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Trades.Services;

namespace Trades.Views
{
    class DefaultView
    {
        IOView ioView;

        public DefaultView()
        {            
            ioView = new IOView();
            ReadPortfolio();
        }

        private void ReadPortfolio()
        {            
            int numeroTrades;
            DateTime referenceDate;            
            List<ITrade> portfolio = new List<ITrade>();

            try
            {                                
                referenceDate = ioView.ReadReferenceDate();
                numeroTrades = ioView.ReadNumberOfTrades();                
                portfolio = ioView.ReadPortfolioTrades(referenceDate, numeroTrades);

                ioView.PrintTradesCategory(portfolio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }        
    }
}
