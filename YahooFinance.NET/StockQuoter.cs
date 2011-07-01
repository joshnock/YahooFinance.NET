using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YahooFinance.NET
{
    public class StockQuoter
    {
        public yQuote StockQuote(string ticker)
        {
            yQuote quote = new yQuote();
            string requesturl = ConfigurationManager.AppSettings["URL"];
            requesturl.Replace("||TICKER||", ticker);

            //TODO:  MAKE WEB REQUEST TO THE URL

            //TODO: DESERIALIZE THE JSON RESPONSE TO AN OBJECT


            return quote;
        }
    }
}
