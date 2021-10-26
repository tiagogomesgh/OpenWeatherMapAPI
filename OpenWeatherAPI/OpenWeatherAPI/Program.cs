using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace OpenWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please Enter your API Key:");
            var apiKey = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter a city's name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedRes = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedRes);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose another city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }
            }

            // var weather = client.GetStringAsync("api.openweathermap.org/data/2.5/weather?q={Seminole}&appid={59c7ce86691661483579754da6371da8}");
            // System.Console.WriteLine(weather);        
        }

    }
}
