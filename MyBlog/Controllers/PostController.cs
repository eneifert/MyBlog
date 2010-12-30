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
        EricBlogDataContext _ericBlogDataContext = new EricBlogDataContext();
        private const int PageSize = 8;        
     
        public ActionResult Index(int page=1, string query="")
        {
            var posts = _ericBlogDataContext.Posts.Where(x => x.Title.ToUpper().Contains(query.ToUpper()));

            var list = new PagedList<Post>(posts, page -1, PageSize);

            if (page < 1 || page > list.PageCount)
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
            var post = _ericBlogDataContext.Posts.SingleOrDefault(x => x.PostID == id);
            if (post == null)
                return View("404");
            return View(post);
        }

        //
        // GET: /Post/Create
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                post.PostID = _ericBlogDataContext.Posts.OrderByDescending(x => x.PostID).First().PostID + 1;
                _ericBlogDataContext.Posts.InsertOnSubmit(post);
                _ericBlogDataContext.SubmitChanges();

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
            var post = _ericBlogDataContext.Posts.SingleOrDefault(x => x.PostID == id);
            return View(post);            
        }

        //
        // POST: /Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var post = _ericBlogDataContext.Posts.SingleOrDefault(x => x.PostID == id);

            try
            {                
                UpdateModel(post, collection.ToValueProvider());
                _ericBlogDataContext.SubmitChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(post);
            }
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            var post = _ericBlogDataContext.Posts.SingleOrDefault(x => x.PostID == id);
            _ericBlogDataContext.Posts.DeleteOnSubmit(post);
            _ericBlogDataContext.SubmitChanges();

            TempData["message"] = "*Post was deleted";

            return RedirectToAction("Index");
        }  
    }
}
