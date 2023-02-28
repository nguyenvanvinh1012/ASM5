using ASM5.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASM5.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var context = new BookModelContext();
            return View(context.Books.ToList());
        }
        public ActionResult GetBookCategory(int id)
        {
            var context = new BookModelContext();
            return View("Index", context.Books.Where(p => p.CategoryId == id).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var context = new BookModelContext();
            ViewBag.ListCategory = context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            var context = new BookModelContext();

            if(ModelState.IsValid)
            {
                context.Books.Add(newBook);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var context = new BookModelContext();
            Book findBook = context.Books.FirstOrDefault(p => p.Id== id);
            if(findBook==null) {
                return HttpNotFound("Sách không tồn tại...!");
            }
            return View(findBook);
           
        }
        [HttpPost]
        public ActionResult Delete(Book findBook)
        {
            var context = new BookModelContext();
            Book deBook = context.Books.FirstOrDefault(p => p.Id == findBook.Id);
            if (findBook == null)
            {
                return HttpNotFound("Sách không tồn tại...!");
            }
            context.Books.Remove(deBook);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var context = new BookModelContext();
            Book findBook = context.Books.FirstOrDefault(p => p.Id == id);
            ViewBag.ListCategory = context.Categories.ToList();
            if (findBook == null)
            {
                return HttpNotFound("Sách không tồn tại...!");
            }
            return View(findBook);
        }
        [HttpPost]
        public ActionResult Edit(Book editBook)
        {
            var context = new BookModelContext();
            Book findBook = context.Books.FirstOrDefault(p => p.Id == editBook.Id);
            if (findBook == null)
            {
                return HttpNotFound("Sách không tồn tại...!");
            }

            findBook.Author = editBook.Author;
            findBook.Category = editBook.Category;
            findBook.CategoryId = editBook.CategoryId;
            findBook.Price= editBook.Price; 
            findBook.Description = editBook.Description;
            findBook.Title = editBook.Title;
            findBook.Image= editBook.Image;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var context = new BookModelContext();
            Book fristBook = context.Books.FirstOrDefault(p => p.Id == id);
            if (fristBook == null)
            {
                return HttpNotFound("Sách không tồn tại...!");
            }
            return View(fristBook);
        }

        public ActionResult GetCategory()
        {
            var context = new BookModelContext();
            var listCategory = context.Categories.ToList();
            return PartialView(listCategory);
        }
    }

}