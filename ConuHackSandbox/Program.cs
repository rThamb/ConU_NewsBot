﻿using System;
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

            //readTwitterDMS();
            //writeTwitterDMS();
            
            List<News> news = getArticles();

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


            var response2 = "";
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(7);

            var timer = new System.Threading.Timer((e) =>
            {
                News item = news[0];
                news.Remove(item); 
                response2 = twitter.Tweet(item.Url).Result;

                if (news.Count < 2)
                    news = getArticles(); 

            }, null, startTimeSpan, periodTimeSpan);

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
            Requester requester = new Requester();
            string response = requester.makeGetHttpRequest("https://api.twitter.com/1.1/followers/ids.json");
            

            SendDirectMessageOptions options = new SendDirectMessageOptions();
            //options.UserId = J
            options.Text = "dm messages";
            TwitterService service = new TwitterService(ConsumerKey, ConsumerKeySecret,AccessToken,AccessTokenSecret);
            TwitterDirectMessage dm = service.SendDirectMessage(options);


        }

        private static void readTwitterDMS()
        {
            TwitterService service = new TwitterService(ConsumerKey, ConsumerKeySecret, AccessToken, AccessTokenSecret);
            var directMessagesList = service.ListDirectMessagesReceived(new ListDirectMessagesReceivedOptions { Count = 200 });

            int i = 0;
        }
    }
}
