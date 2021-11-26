using System;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace ConsimpleApp
{
    class Controller
    {
        public void Run()
        {
            bool check = true;
            do
            {
                try
                {
                    SetCatalogJSON();
                    new View().ShowData(GetCatalogFromJSON());
                    check = new View().RetryMessage();
                    if (check)
                        Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (check);
            Console.WriteLine("\nPress ENTER to close the application.");
            Console.ReadLine();
        }
        private async void SetCatalogJSON()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://tester.consimple.pro/");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            HttpContent responseContent = response.Content;
            string data = await responseContent.ReadAsStringAsync();
            using (StreamWriter sw = new StreamWriter("catalog.json", false))
                sw.WriteLine(data);
        }
        private Catalog GetCatalogFromJSON()
        {
            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(File.ReadAllText("catalog.json"));
            return catalog;
        }
    }
}
