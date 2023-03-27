using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System;

namespace Data1C.Model
{
    public class JsonParser
    {
        public WebClient client = new WebClient();

        List<Book> books = new List<Book>();

        public JsonParser() { }
        public List<Book> ParseDataFrom1C(WebClient client, string url)
        {

            client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + "0JDQtNC80LjQvV/QntCfOg==");
            var json = client.DownloadString(url);
            var ParsedJson = JObject.Parse(json);
            JArray a = (JArray)ParsedJson["value"];

            return books = a.ToObject<List<Book>>();
        }


    }
}
