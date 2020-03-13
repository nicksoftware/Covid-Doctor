using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaDoctor.Models
{
    public class Article
    {
        public  int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Publish_Date { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public string Name { get;  set; }
        public string Date { get; set; }
        public string AverageReadingTime { get; set; }
        public string Description { get;  set; }
        public bool IsBookmarked { get; internal set; }
    }
}
