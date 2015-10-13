using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFinance.NET.Exceptions
{
    public class YahooExceptionNoComponentsDataAvailable : Exception
    {
        public override string Message
        {
	        get 
	        {
                return "Não há dados disponíveis no momento para os componentes.";
	        }
        }
    }
}
