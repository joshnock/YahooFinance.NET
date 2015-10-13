using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YahooFinance.NET.Exceptions;

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
            string content = MakeWebRequestToTheURL(requesturl);

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
            string content = MakeWebRequestToTheURL(requesturl);

            // DESERIALIZE THE JSON RESPONSE TO AN OBJECT
            JObject yahooresult = JObject.Parse(content);
            JToken result = yahooresult["query"]["results"]["quote"];
            qte = JsonConvert.DeserializeObject<yQuote>(result.ToString());


            return qte;
        }

        public IList<string> GetStockQuoteList()
        {
            //TODO: html

            //select * from html where url='http://finance.yahoo.com/q/cp?s=%5EBVSP+Components'

            var list = new List<string>();
            //yQuote qte = new yQuote();

            //select * from yahoo.finance.industry where id in (select industry.id from yahoo.finance.sectors)
            string requesturl = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.industry%20where%20id%20in%20(select%20industry.id%20from%20yahoo.finance.sectors)&format=json&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

            // MAKE WEB REQUEST TO THE URL
            string content = MakeWebRequestToTheURL(requesturl);

            // DESERIALIZE THE JSON RESPONSE TO AN OBJECT
            JObject yahooresult = JObject.Parse(content);
            JArray industryArray = yahooresult["query"]["results"]["industry"] as JArray;
            foreach (var industry in industryArray)
            {
                JArray companies = industry["company"] as JArray;
                if (companies != null)
                {
                    foreach (var company in companies)
                    {
                        JValue symbol = (company["symbol"] as JValue);
                        list.Add(symbol.ToString());
                    }
                }
            }

            //qte = JsonConvert.DeserializeObject<yQuote>(result.ToString());

            return list;
        }

        private static string MakeWebRequestToTheURL(string requesturl)
        {
            // MAKE WEB REQUEST TO THE URL
            WebRequest request = WebRequest.Create(requesturl);
            WebResponse response = request.GetResponse();

            Stream receive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader read = new StreamReader(receive, encoding);

            string content = read.ReadToEnd();
            return content;
        }

        public IList<string> GetStockQuoteListBovespa()
        {
            List<string> URIList = new List<string>() { 
                "http://finance.yahoo.com/q/cp?s=^BVSP&c=0", 
                "http://finance.yahoo.com/q/cp?s=^BVSP&c=1" 
            };

            return GetStockQuoteListYahooWebSite(URIList);
        }

        public IList<string> GetStockQuoteListNasdaq()
        {
            List<string> URIList = new List<string>();
            for (int i = 0; i <= 52; i++)
            {
                URIList.Add("http://finance.yahoo.com/q/cp?s=^IXIC&c=" + i);
            };

            return GetStockQuoteListYahooWebSite(URIList);
        }

        public IList<string> GetStockQuoteListDownJones()
        {
            List<string> URIList = new List<string>();
            for (int i = 0; i <= 1; i++)
            {
                URIList.Add("http://finance.yahoo.com/q/cp?s=^DJA&c=" + i);
            };

            return GetStockQuoteListYahooWebSite(URIList);
        }

        private static IList<string> GetStockQuoteListYahooWebSite(List<string> URIList)
        {
            var requesturl = URIList[0];

            // MAKE WEB REQUEST TO THE URL
            string content = MakeWebRequestToTheURL(requesturl);

            var list = new List<string>();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            //html
            htmlDoc.LoadHtml(content);
            var html = htmlDoc.DocumentNode.ChildNodes[2];
            //body
            var body = html.ChildNodes[1];
            //4º div - id="screen"
            var divScreen = body.ChildNodes[3];
            //4º div - id="rightcol"
            var divRightCol = divScreen.ChildNodes[5];
            //2º table - id="yfncsumtab"
            var tableYfncSumTab = divRightCol.ChildNodes[3];

            if (tableYfncSumTab.InnerHtml.Contains("There is no Components data available for"))
                throw new YahooExceptionNoComponentsDataAvailable();

            //2º tr 
            var tr = tableYfncSumTab.ChildNodes[1];
            //1º td
            var td = tr.ChildNodes[0];
            //2º table - class="yfnc_tableout1"
            var tableYfncTableOut1 = td.ChildNodes[3];
            //tr
            var trTableAcoes = tableYfncTableOut1.ChildNodes[0];
            //td
            var tdTableAcoes = trTableAcoes.ChildNodes[0];
            //Table
            var tableAcoes = tdTableAcoes.ChildNodes[0];
            //linhas
            int ignorar = 1;
            foreach (var linhaAcoes in tableAcoes.ChildNodes)
            {
                //primeira é header, por isso ignora
                if (ignorar == 1)
                {
                    ignorar--;
                    continue;
                }
                //resto é ação
                //td
                var conlunaAcao = linhaAcoes.ChildNodes[0];
                //b
                var b = conlunaAcao.ChildNodes[0];
                //a
                var a = b.ChildNodes[0];

                list.Add(a.InnerText);
            }

            return list;
        }
    }
}
