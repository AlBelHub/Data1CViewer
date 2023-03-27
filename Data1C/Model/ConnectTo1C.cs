using System.Net;
using System.Text;

namespace Data1C.Model
{
    public class ConnectTo1C
    {
        public bool Attention = false;

        public string url 
        {
            get { return url; }
            set { url = value; }
        }

        public string connString
        {
            get { return connString; }
            set { connString = value; }
        }
          
        public void Connect1Cdb()
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + "0JDQtNC80LjQvV/QntCfOg==");
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = url;

            Attention= true;
        }
    }
}
