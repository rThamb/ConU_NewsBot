using IBM.WatsonDeveloperCloud.Conversation.v1;
using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace ConuHackSandbox
{
    class Program
    {
        private const string ConsumerKey = "vsuhigNC283qd0EeG8lum8Pun";
        private const string ConsumerKeySecret = "bzGmjQdKeKxbZMSRae5iYTRrTW5C9tuJ1pwQzQvMkhkiXFh8Kw";
        private const string AccessToken = "957291496297902080-neyhZ6XNQ6v7qMWNsa6mumJi2AmEyxV";
        private const string AccessTokenSecret = "hj6xS1DOiYmefRLOHukaxQrQJZBnk4wromaY61NNxCsB5";

        static void Main(string[] args)
        {
            Conversation convo = new Conversation();
            ConversationService conversation = convo.AuthenticateConvo();
            String id = "02c3be26-c67d-4a08-9326-081ee1561dd9";
            

            //readTwitterDMS();
            //writeTwitterDMS();

            // List<News> news = getArticles();
           // MessageResponse response = convo.Messenger(conversation, "", id); //Empty string = Read dm
           // Console.WriteLine(response.Output); //1st part of sent dm
            //News articleToSend = getArticle(response.Output["entity"]);

            string ConsumerKey = "vsuhigNC283qd0EeG8lum8Pun",
               ConsumerKeySecret = "bzGmjQdKeKxbZMSRae5iYTRrTW5C9tuJ1pwQzQvMkhkiXFh8Kw",
                AccessToken = "957291496297902080-neyhZ6XNQ6v7qMWNsa6mumJi2AmEyxV",
                AccessTokenSecret = "hj6xS1DOiYmefRLOHukaxQrQJZBnk4wromaY61NNxCsB5";

            var twitter = new Twitter(
                ConsumerKey,
                ConsumerKeySecret,
                AccessToken,
                AccessTokenSecret
                );

            //writeTwitterDMS();
            /*
                        var response2 = "";
                        var startTimeSpan = TimeSpan.Zero;
                        var periodTimeSpan = TimeSpan.FromMinutes(7);

                       // var periodTimeSpan = TimeSpan.FromSeconds(7);

                        var timer = new System.Threading.Timer((e) =>
                        {
                            News item = news[0];
                            news.Remove(item); 
                            response2 = twitter.Tweet(item.Url).Result;

                            if (news.Count < 2)
                                news = getArticles(); 

                        }, null, startTimeSpan, periodTimeSpan);
                        */
            Console.ReadKey();


        }

        private static List<News> getArticles()
        {
            Requester req = new Requester();
            String url = "https://newsapi.org/v2/top-headlines?sources=google-news&apiKey=1430a5758123471494dbbf502e28a873";
            String response = req.makeGetHttpRequest(url);
            List<News> news = req.getArticles(response);
            return news;
        }

        private static void writeTwitterDMS()
        {

            var twitter = new Twitter(
                ConsumerKey,
                ConsumerKeySecret,
                AccessToken,
                AccessTokenSecret
                );
            var response = twitter.sendMessages("894821884822519808", "wassup").Result;
            Console.WriteLine(response);

        }

        //Gets a random single article related to Conversation DMs
        private static News getArticle(string entity)
        {
            Requester req = new Requester();
            string url = "";

            switch (entity)
            {
                case "breaking":
                    url = "https://newsapi.org/v2/top-headlines?sources=google-news&apiKey=1430a5758123471494dbbf502e28a873";
                    break;
                case "localnews":
                    url = "https://newsapi.org/v2/top-headlines?country=ca&apiKey=1430a5758123471494dbbf502e28a873";
                    break;
                case "games":
                    url = "https://newsapi.org/v2/top-headlines?sources=ign&apiKey=1430a5758123471494dbbf502e28a873";
                    break;
                case "sports":
                    url = "https://newsapi.org/v2/top-headlines?sources=bbc-sport&apiKey=1430a5758123471494dbbf502e28a873";
                    break;
                default:
                    break;
            }

            String response = req.makeGetHttpRequest(url);
            List<News> news = req.getArticles(response);
            Random rdm = new Random();
            int r = rdm.Next(news.Count);

            return news[r];
        }
    }
}
