using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFinance.NET
{
    public class yQuery
    {
        public int count;
        public DateTime created;
        public string lang;

        public class results
        {
            public yQuote[] quote;
        }

    }

}
