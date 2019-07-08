using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam_ASP.Models;
using Microsoft.AspNetCore.Identity;
using Exam_ASP.Data;

namespace Exam_ASP.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private BookShopContext db;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, BookShopContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;

        }
        public IActionResult Index(string Name = "")
        {
            List<Book> books;
            if (Name == "")
                books = db.Books.ToList();
            else
            {
                var genre = db.Genres.ToList().Find(c => c.Name == Name);
                books = db.Books.ToList().FindAll(b => b.GenreID == genre.ID);
            }


            var commList = db.Comments.ToList();
            var commentsCountList = new List<int>();
            foreach (var book in books)
            {
                var commentsCount = commList.FindAll(x => x.BookID == book.ID).Count;
                commentsCountList.Add(commentsCount);
            }
            ViewBag.CommentsCount = commentsCountList;


            List<string> authorNames = new List<string>();
            foreach (Book book in books)
                authorNames.Add(db.Authors.Find(book.AuthorID).Name);
            ViewBag.AuthorNames = authorNames;

            List<string> genreNames = new List<string>();
            foreach (Book book in books)
                genreNames.Add(db.Genres.Find(book.GenreID).Name);
            ViewBag.Genres = genreNames;


            return View(books);

        }

        public IActionResult Info(int id)
        {
            var book = db.Books.Find(id);
            ViewBag.Author = db.Authors.Find(book.AuthorID).Name;
            ViewBag.Genre = db.Genres.Find(book.GenreID).Name;

            var commList = db.Comments.ToList();
            var comments = commList.FindAll(x => x.BookID == id);


            ViewBag.Comments = comments;
            ViewBag.CountOfComments = comments.Count;

            return View(book);
        }

        public IActionResult AddComment(int id, string CommentTextMy)
        {
            var book = db.Books.Find(id);
            Comment comment = new Comment();
            comment.CommentText = CommentTextMy;
            comment.DateTime = DateTime.Now;
            comment.BookID = id;
            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Info", book);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
