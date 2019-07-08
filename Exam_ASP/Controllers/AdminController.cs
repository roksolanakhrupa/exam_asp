using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Exam_ASP.Data;
using Exam_ASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_ASP.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private BookShopContext db;
        private IHostingEnvironment appEnvironment;

        public AdminController(BookShopContext db, IHostingEnvironment appEnvironment)
        {
            this.db = db;
            this.appEnvironment = appEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var books = db.Books.ToList();
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Genres = db.Genres.ToList();
            return View(books);
        }


        [HttpGet]
        public IActionResult CreateBook()
        {
            ViewBag.Authors = db.Authors;
            ViewBag.Genres = db.Genres;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book, IFormFile file)
        {
            string path = "/files/" + file.FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }



            book.ImagePath = Path.Combine(appEnvironment.WebRootPath, path);

            book.Author = db.Authors.Find(book.AuthorID);
            db.Books.Add(book);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddAuthor(string name)
        {
            db.Authors.Add(new Author { Name = name });
            db.SaveChanges();
            return Redirect("/");
        }

        public IActionResult AddGenre(string name)
        {
            db.Genres.Add(new Genre { Name = name });
            db.SaveChanges();
            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Genres = db.Genres.ToList();
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book, IFormFile file)
        {
            string path = "/files/" + file.FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            book.ImagePath = Path.Combine(appEnvironment.WebRootPath, path);

            db.Books.Update(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}