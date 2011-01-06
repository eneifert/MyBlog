using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private IBlogDataContext _blogDataContext;
        private const int PageSize = 8;        
     
        public PostController(IBlogDataContext blogDataContext)
        {
            _blogDataContext = blogDataContext;
        }

        public ActionResult Index(int page=1, string query="")
        {
            var posts = _blogDataContext.Posts.Where(x => x.Title.ToUpper().Contains(query.ToUpper()));

            var list = new PagedList<Post>(posts, page, PageSize);

            if (page < 0 || page > list.PageCount)
            {
                TempData["message"] = "That page doesn't exists.";
                return RedirectToAction("Index");
            }

            return View(list);
        }


        //
        // GET: /Post/Details/5
        public ActionResult Details(int id)
        {
            var post = _blogDataContext.Posts.SingleOrDefault(x => x.PostID == id);
            if (post == null)
                return View("404");
            return View(post);
        }

        //
        // GET: /Post/Create
        public ActionResult Create()
        {

            //Uses my own custom extension method
            ViewData["Categories"] = _blogDataContext.Categories.ToSelectList("CategoryID", "CategoryName");
            return View();
        } 

        //
        // POST: /Post/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                post.PostID = _blogDataContext.Posts.OrderByDescending(x => x.PostID).First().PostID + 1;
                _blogDataContext.Posts.InsertOnSubmit(post);
                _blogDataContext.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(post);
            }
        }
        
        //
        // GET: /Post/Edit/5 
        public ActionResult Edit(int id)
        {            
            var post = _blogDataContext.Posts.SingleOrDefault(x => x.PostID == id);

            //Uses my own custom extension method
            ViewData["Categories"] = _blogDataContext.Categories.ToSelectList("CategoryID", "CategoryName");
            return View(post);            
        }

        //
        // POST: /Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            //Custom form validation
            if (post.Title.Length == 1)
                ModelState.AddModelError("Title", "Your title has to be a little bit longer");

            ViewData["Categories"] = _blogDataContext.Categories.ToSelectList("CategoryID", "CategoryName");

            if (ModelState.IsValid)
            {
                var p = _blogDataContext.Posts.SingleOrDefault(x => x.PostID == post.PostID);
                UpdateModel(p);

                _blogDataContext.SubmitChanges();
            }

            return View(post);
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            var post = _blogDataContext.Posts.SingleOrDefault(x => x.PostID == id);
            _blogDataContext.Posts.DeleteOnSubmit(post);
            _blogDataContext.SubmitChanges();

            TempData["message"] = "*Post was deleted";

            return RedirectToAction("Index");
        }  
    }
}
