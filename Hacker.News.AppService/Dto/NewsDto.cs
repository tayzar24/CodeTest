using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.AppService.Dto
{
    public class NewsDto
    {
        public string Title { get; set; }   
        public string URL { get; set; }   
        public string PostedBy { get; set; }   
        public string Time { get; set; }   
        public int Score { get; set; }   
        public string CommentCount { get; set; }   
    }

    public class DetailDto
    {
        public string by { get; set; }
        public string ismaildonmez { get; set; }
        public string descendants { get; set; }
        public string id { get; set; }
        public int[] kids { get; set; }
        public string score { get; set; }
        public string time { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}
