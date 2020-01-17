using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetC.JuniorDeveloperExam.Web.Model;
using Newtonsoft.Json;


namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            Blogs blogs = new Blogs();
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Blog-Posts.json";

            // read file into a string and deserialize JSON to a type
            //IEnumerable<Blog> blogs1 = JsonConvert.DeserializeObject<IEnumerable<Blog>>(System.IO.File.ReadAllText(path));

            // deserialize JSON directly from a file

            if (System.IO.File.Exists(path))
            {
                using (StreamReader reader = System.IO.File.OpenText(path))
                {
                    //JsonSerializer serializer = new JsonSerializer();
                    // Blog blogs = (Blog)serializer.Deserialize(reader, typeof(Blog));
                    //IEnumerable<Blog> blogs= (IEnumerable<Blog>)serializer.Deserialize(reader, typeof(Blog));


                    var json = reader.ReadToEnd();
                    
                    // var model = JsonConvert.DeserializeObject<Blog>(json);
                    //JsonConvert.DeserializeObject<List<Blog>>(json);
                   if (json != null)
                    {
                        blogs = JsonConvert.DeserializeObject<Blogs>(json);
                    }
                    int offset = id - 1; //offeset because the array starts at 0
                   
                    try
                    {
                        var specificBlog = blogs.BlogPosts[offset];
                        return View(specificBlog);
                        //return Content(blogs.BlogPosts[offset].Title);
                    }
                    catch (Exception e)
                    {
                        return Content(e.Message);
                    }
                    
                    //IEnumerable<Blog> blogs = JsonConvert.DeserializeObject<IEnumerable<Blog>>(json);
                }
                //var blogReturn = blogs;

            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(NewComments comments)
        {
            return Content($"Hello {comments.email}");
            //return View();
        }
    }
}