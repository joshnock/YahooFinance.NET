using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFinance.NET
{
    public class yQuote
    {
            public string symbol { get; set; }
            public decimal Ask { get; set; }
            public int AverageDailyVolume { get; set; }
            public decimal Bid { get; set; }
            public decimal AskRealtime { get; set; }
            public decimal BidRealtime { get; set; }
            public decimal BookValue { get; set; }
            public string Change_PercentChange { get; set; }
            public decimal Change { get; set; }
            public string Commission { get; set; }
            public decimal ChangeRealtime { get; set; }
            public string AfterHoursChangeRealtime { get; set; }
            public string DividendShare { get; set; }
            public DateTime LastTradeDate { get; set; }
            public DateTime TradeDate { get; set; }
            public decimal EarningsShare { get; set; }
            public string ErrorIndicationreturnedforsymbolchangedinvalid { get; set; }
            public decimal EPSEstimateCurrentYear { get; set; }
            public decimal EPSEstimateNextYear { get; set; }
            public decimal EPSEstimateNextQuarter { get; set; }
            public decimal DaysLow { get; set; }
            public decimal DaysHigh { get; set; }
            public decimal YearLow { get; set; }
            public decimal YearHigh { get; set; }
            public decimal HoldingsGainPercent { get; set; }
            public decimal AnnualizedGain { get; set; }
            public decimal? HoldingsGain { get; set; }
            public string HoldingsGainPercentRealtime { get; set; }
            public decimal? HoldingsGainRealtime { get; set; }
            public string MoreInfo { get; set; }
            public string OrderBookRealtime { get; set; }
            public string MarketCapitalization { get; set; }
            public string MarketCapRealtime { get; set; }
            public string EBITDA { get; set; }
            public decimal ChangeFromYearLow { get; set; }
            public decimal PercentChangeFromYearLow { get; set; }
            public string LastTradeRealtimeWithTime { get; set; }
            public string ChangePercentRealtime { get; set; }
            public decimal ChangeFromYearHigh { get; set; }
            public decimal PercebtChangeFromYearHigh { get; set; }
            public string LastTradeWithTime { get; set; }
            public decimal LastTradePriceOnly { get; set; }
            public string HighLimit { get; set; }
            public string LowLimit { get; set; }
            public string DaysRange { get; set; }
            public string DaysRangeRealtime { get; set; }
            public decimal FiftydayMovingAverage { get; set; }
            public decimal TwoHundreddayMovingAverage { get; set; }
            public decimal ChangeFromTwoHundreddayMovingAverage { get; set; }
            public decimal PercentChangeFromTwoHundreddayMovingAverage { get; set; }
            public decimal ChangeFromFiftydayMovingAverage { get; set; }
            public decimal PercentChangeFromFiftydayMovingAverage { get; set; }
            public string Name { get; set; }
            public string Notes { get; set; }
            public decimal Open { get; set; }
            public decimal PreviousClose { get; set; }
            public decimal PricePaid { get; set; }
            public decimal ChangeinPercent { get; set; }
            public decimal PriceSales { get; set; }
            public decimal PriceBook { get; set; }
            public DateTime ExDividendDate { get; set; }
            public decimal PERatio { get; set; }
            public DateTime DividendPayDate { get; set; }
            public decimal PERatioRealtime { get; set; }
            public decimal PEGRatio { get; set; }
            public decimal PriceEPSEstimateCurrentYear { get; set; }
            public decimal PriceEPSEstimateNextYear { get; set; }
            public string Symbol { get; set; }
            public string SharesOwned { get; set; }
            public decimal ShortRatio { get; set; }
            public DateTime LastTradeTime { get; set; }
            public string TickerTrend { get; set; }
            public decimal OneyrTargetPrice { get; set; }
            public int Volume { get; set; }
            public decimal? HoldingsValue { get; set; }
            public decimal? HoldingsValueRealtime { get; set; }
            public string YearRange { get; set; }
            public string DaysValueChange { get; set; }
            public string DaysValueChangeRealtime { get; set; }
            public string StockExchange { get; set; }
            public decimal? DividendYield { get; set; }
            public decimal? PercentChange { get; set; }
    }
}
