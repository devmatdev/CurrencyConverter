using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace CurrencyConverter
{
    class ParserXML
    {
        // XML file to List of objects
        public static List<Rate> Parser(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            List<Rate> rates = new List<Rate>();

            XmlNodeList nodes = xmlDoc.SelectNodes("//*[@currency]");

            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    var rate = new Rate()
                    {
                        Currency = node.Attributes["currency"].Value,
                        Value = Decimal.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-Us"))
                    };
                    rates.Add(rate);
                }
            }
            return rates;
        }    
    }
}
