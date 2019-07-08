using Exam_ASP.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Components
{
    public class GenreMenuViewComponent:ViewComponent
    {
        private BookShopContext db;

        public GenreMenuViewComponent(BookShopContext context)
        {
            this.db = context;
        }

        public IViewComponentResult Invoke()
        {
            var genres = db.Genres.ToList();
            return View(genres);
        }
    }
}
