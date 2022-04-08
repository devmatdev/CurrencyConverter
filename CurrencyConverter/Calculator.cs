using System;
using System.Collections.Generic;
using System.Linq;


namespace CurrencyConverter
{
    // Calculator class with static SelectCurrency method and ConvertToSelectedCurrency method. 
    class Calculator
    {
        public decimal EuroAmount { get; set; }
        public Rate SelectedCurrency { get; set; }

        public Calculator(decimal euroAmount, Rate selectedCurrency)
        {
            EuroAmount = euroAmount;
            SelectedCurrency = selectedCurrency;
        }
        
        public static Rate SelectCurrency(List<Rate> currencyList, string currencyName) =>          
            currencyList.FirstOrDefault(x => x.Currency == currencyName);

        public decimal ConvertToSelectedCurrency() =>
            EuroAmount * SelectedCurrency.Value;

    }
}
