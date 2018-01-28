using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; 

namespace ConuHackSandbox
{
    public class Requester
    {

        public Requester()
        { }


        public String makeGetHttpRequest(String url)
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }
/*
        public String makePostHttpRequest(String url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);


            String OAUTH = "oauth_consumer_key=\"vsuhigNC283qd0EeG8lum8Pun\", oauth_nonce=\"a\", oauth_signature_method=\"HMAC - SHA1\", oauth_signature=\"pKJbkr6y9q % 2FJzJDzukqhLBDxDb4 % 3D\", oauth_timestamp=\"1517105842\", oauth_token=\"957291496297902080 - neyhZ6XNQ6v7qMWNsa6mumJi2AmEyxV\", oauth_version=\"1.0\"";

            var postData = "thing1=hello";
            postData += "&thing2=world";
            var data = Encoding.ASCII.GetBytes("");

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
        */
        public List<News> getArticles(String jsonText)
        {
            JObject json = JObject.Parse(jsonText);

            JToken articles = json["articles"];

            JArray news = JArray.Parse(articles.ToString());

            List<News> newsToShow = new List<News>();
            foreach (var item in news)
            {
                string author = item["author"].ToString();
                string title = item["title"].ToString();
                string description = item["description"].ToString();
                string imageUrl = item["author"].ToString();
                string url = item["url"].ToString();
                newsToShow.Add(new News(author, title, description, imageUrl, url));
            }
            return newsToShow; 
        }


        



    }
}
