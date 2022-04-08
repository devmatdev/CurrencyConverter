using System;

namespace CurrencyConverter
{
    class Program
    {
        //user interface and validation of user input
        static void Main(string[] args)
        {
            string[] currencyArray = { "USD", "JPY", "BGN", "CZK","DKK", "GBP", "HUF", "PLN", "RON", "SEK", "CHF", "ISK", "NOK", "HRK", 
                 "TRY", "AUD", "BRL", "CAD", "CNY", "HKD", "IDR", "ILS", "INR", "KRW", "MXN", "MYR", "NZD", "PHP", "SGD", "THB", "ZAR" }; 
            
            var currencyList = ParserXML.Parser("eurofxref-daily.xml"); //here we can enter other file path

            Console.WriteLine("Witaj w kalkulatorze euro na wybraną walutę");
            Console.Write("Do wyboru: ");
            foreach (var cur in currencyArray) 
            {
                Console.Write($"{cur} ");
            }

            string name = default;
            bool check = false;
            while (check != true)
            {
                Console.WriteLine("\nNa jaką walutę chcesz wymienić?");
                Console.Write("Podaj skrót: ");
                name = Console.ReadLine().ToUpper();
                check = Array.Exists(currencyArray, x => x == name);
                if(check==false)
                    Console.WriteLine("Nieprawidłowa waluta, wprowadź jeszcze raz");
            }

            bool isNumber = false;
            decimal euroAmount = 0;
            while (euroAmount <= 0 ||isNumber!=true)
            {
                Console.WriteLine("Ile euro chcesz wymienić?");
                Console.Write("Podaj wartość: ");
                string euroAmountString = Console.ReadLine();
                isNumber = decimal.TryParse(euroAmountString, out euroAmount);
                if(euroAmount <= 0 || isNumber != true)
                    Console.WriteLine("Nieprawidłowy format danych, wprowadź jeszcze raz");
            }

            Rate selectedCurrency = Calculator.SelectCurrency(currencyList, name);
            var calculator = new Calculator(euroAmount, selectedCurrency);
            decimal convertedCurrency = calculator.ConvertToSelectedCurrency();
            Console.WriteLine($"{euroAmount} EUR po wymianie to {convertedCurrency.ToString("N2")} {name}");
            Console.WriteLine("Wciśnij ENTER aby zakończyć");
            Console.ReadKey();

        }

    }
}
