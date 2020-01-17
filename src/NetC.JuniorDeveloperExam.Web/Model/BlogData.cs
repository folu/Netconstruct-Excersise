using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Model
{
    public class BlogData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string htmlContent { get; set; }
        public IList<Comments> Comments { get; set; }

    }

    public class Comments
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
}