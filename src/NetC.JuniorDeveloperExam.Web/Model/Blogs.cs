using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Model
{
    public class Blogs
    {
        public IList<BlogData> BlogPosts { get; set; }
    }

    public class NewComments
    {
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
}