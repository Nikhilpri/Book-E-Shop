using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrimaryKeyIntTest.Models;

namespace PrimaryKeyIntTest.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult FetchBooks(string query)
        {
            /*var finalList = new List<Book>();
            foreach (var item in db.Books)
            {

                if (item.ToString().Contains(query))
                    finalList.Add(item);
            }*/

            /*var list1 = from c in db.Books.ToList() where c.BookName.Contains(query) select c;
            var list2 = from c in db.Books.ToList() where c.Author.Contains(query) select c;
            var list3 = from c in db.Books.ToList() where c.BookCategory.Contains(query) select c;
            var list4 = from c in db.Books.ToList() where c.TimeStamp.Year.ToString() == query select c;
            var finalList = list1.ToList().Concat(list2.ToList())
                                    .Concat(list3.ToList()).Concat(list4.ToList());*/

            var finalList = db.Books.ToList();
            return View(finalList);
        }
        // GET: Books
        public ActionResult Archive()
        {
            return View(db.Books.ToList());
        }




        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult ConfirmArchive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            if (book.Archived == true)
            {
                book.Archived = false;
            }
            else
                book.Archived = true;
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmArchive([Bind(Include = "Id,BookName,BookCode,BookDescription,Author,BookCategory,BookType,Option,Rate,Discounts,TimeStamp,Archived")] Book book)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Archive");
            }
            return View(book);
        }



        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookName,BookCode,BookDescription,Author,BookCategory,BookType,Option,Rate,Discounts,TimeStamp,Archived")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.TimeStamp = DateTime.Now;
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,BookCode,BookDescription,Author,BookCategory,BookType,Option,Rate,Discounts,TimeStamp,Archived")] Book book)
        {
            if (ModelState.IsValid)
            {
                //book.TimeStamp = DateTime.Now;
               db.Entry(book).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
