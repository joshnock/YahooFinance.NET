using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFinance.NET
{
    public class StockQuoter
    {
        /// <summary>
        /// This original method grabs the YQL url from the config file, but it was causing problems int testing
        /// so i created the second method where the url is manually passed in.
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public yQuote StockQuote(string ticker)
        {
            yQuote qte = new yQuote();
            string requesturl = ConfigurationManager.AppSettings["URL"];
            requesturl = requesturl.Replace("||TICKER||", ticker);

            // MAKE WEB REQUEST TO THE URL
            WebRequest request = WebRequest.Create(requesturl);
            WebResponse response = request.GetResponse();

            Stream receive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader read = new StreamReader(receive, encoding);

            string content = read.ReadToEnd();

            // DESERIALIZE THE JSON RESPONSE TO AN OBJECT
            JObject yahooresult = JObject.Parse(content);
            JToken result = yahooresult["query"]["results"]["quote"];
            qte = JsonConvert.DeserializeObject<yQuote>(result.ToString());

            return qte;
        }

        public yQuote StockQuote(string ticker, string url)
        {


            yQuote qte = new yQuote();
            string requesturl = url;
            requesturl = requesturl.Replace("||TICKER||", ticker);

            // MAKE WEB REQUEST TO THE URL
            WebRequest request = WebRequest.Create(requesturl);
            WebResponse response = request.GetResponse();

            Stream receive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader read = new StreamReader(receive, encoding);

            string content = read.ReadToEnd();

            // DESERIALIZE THE JSON RESPONSE TO AN OBJECT
            JObject yahooresult = JObject.Parse(content);
            JToken result = yahooresult["query"]["results"]["quote"];
            qte = JsonConvert.DeserializeObject<yQuote>(result.ToString());


            return qte;
        }
    }
}
