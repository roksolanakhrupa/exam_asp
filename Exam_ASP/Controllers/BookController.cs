using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam_ASP.Data;
using Exam_ASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam_ASP.Controllers
{
    public class BookController : Controller
    {
        private BookShopContext db;

        public BookController(BookShopContext db)
        {
            this.db = db;
        }
       
    }
}