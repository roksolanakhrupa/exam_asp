using Exam_ASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_ASP.Data
{
    public class BookShopContext:IdentityDbContext<User>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public BookShopContext(DbContextOptions<BookShopContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
