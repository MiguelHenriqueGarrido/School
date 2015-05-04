using MonitrGw.Handlers;
using MonitrGw.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitrGw
{
    public class MonitrEvent
    {
        private readonly DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private System.Collections.Generic.Dictionary<string, System.Delegate> eventDict;

        public MonitrEvent()
    {
        eventDict = new System.Collections.Generic.Dictionary<string, System.Delegate>();
        eventDict.Add("LastNewsEventHandler", null);
        eventDict.Add("StockCompetitorsEventHandler", null);
        eventDict.Add("StockAnalysisEventHandler", null);
    }

        public event LastNewsEventHandler LastNewsEvent
        {
            add
            {
                lock (eventDict)
                {
                    eventDict["LastNewsEventHandler"] = (LastNewsEventHandler)eventDict["LastNewsEventHandler"] + value;
                }
            }
            remove
            {
                lock (eventDict)
                {
                    eventDict["LastNewsEventHandler"] = (LastNewsEventHandler)eventDict["LastNewsEventHandler"] - value;
                }
            }
        }

        public event StockCompetitorsEventHandler StockCompetitorsEvent
        {
            add
            {
                lock (eventDict)
                {
                    eventDict["StockCompetitorsEventHandler"] = (StockCompetitorsEventHandler)eventDict["StockCompetitorsEventHandler"] + value;
                }
            }
            remove
            {
                lock (eventDict)
                {
                    eventDict["StockCompetitorsEventHandler"] = (StockCompetitorsEventHandler)eventDict["StockCompetitorsEventHandler"] - value;
                }
            }
        }
        public event StockAnalysisEventHandler StockAnalysisEvent
        {
            add
            {
                lock (eventDict)
                {
                    eventDict["StockAnalysisEventHandler"] = (StockAnalysisEventHandler)eventDict["StockAnalysisEventHandler"] + value;
                }
            }
            remove
            {
                lock (eventDict)
                {
                    eventDict["StockAnalysisEventHandler"] = (StockAnalysisEventHandler)eventDict["StockAnalysisEventHandler"] - value;
                }
            }
        }
        public void OnLastNewsEvent() {
            MonitrMarketData data = MonitrApi.GetLastNews();
            var tmp = (LastNewsEventHandler)eventDict["LastNewsEventHandler"];
            if (tmp != null) 
            {
                DateTime date = start.AddMilliseconds(data.Time).ToLocalTime();
                tmp(data.Title, data.Link, date);
            }
        }

        public void OnStockCompetitorsEvent(string stockSymbol)
        {
            List<string> data = MonitrApi.GetStockCompetitors(stockSymbol);
            var tmp = (StockCompetitorsEventHandler)eventDict["StockCompetitorsEventHandler"];
            if (tmp != null) tmp(stockSymbol, data);
        }

        public void OnStockAnalysisEvent(string stockSymbol)
        {
            MonitrAnalysisData data = MonitrApi.GetStockAnalysis(stockSymbol);
            var tmp = (StockAnalysisEventHandler)eventDict["StockAnalysisEventHandler"];
            if (tmp != null) tmp(data);
        }
    }
}
