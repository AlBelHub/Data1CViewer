using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data1C.Model
{
    public class Test1CData
    {

        public void GetData()
        {
            string ConnString = "БиблЗаписи";
            string url = $"http://10.0.0.2/LIBRARY/odata/standard.odata/Catalog_{ConnString}?$format=json";

            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + "0JDQtNC80LjQvV/QntCfOg==");
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = url;

            var json = client.DownloadString(url);
            var ParsedJson = JObject.Parse(json);
            JArray a = (JArray)ParsedJson["value"];

            List<Book> books = a.ToObject<List<Book>>();
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Book() { }

    }
}
