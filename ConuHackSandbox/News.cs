using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; 
namespace ConuHackSandbox
{
    public class News
    {
        private String author;
        private String title;
        private String description;
        private String imageUrl;
        private String url; 

        public News()
        { }

        public News(String author, String title, String des, String imageUrl, String url)
        {
            this.author = author;
            this.title = title;
            this.description = des;
            this.imageUrl = imageUrl;
            this.url = url; 
        }

        


        public String Author
        {
            get { return author; }
            set { author = value; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String ImageUrl
        {
            get { return imageUrl; }
            set { ImageUrl = value; }
        }
        public String Url
        {
            get { return url; }
            set { url = value; }
        }




    }
}
