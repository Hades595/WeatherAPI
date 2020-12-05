using System;
using System.IO;
using System.Net;

namespace WeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("What is the name of your city?");
            string cityname = Console.ReadLine();

            //bd85e0c5d55db50e3d5f0d8fb566ef33
            String test = Get(Url(cityname));
            Console.WriteLine(test);
        }

        public static string Url(string cityname)
        {
            string url;
            url = "api.openweathermap.org/data/2.5/weather?q=" + cityname + "&appid="; //Super secret API key

            return url;

        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
