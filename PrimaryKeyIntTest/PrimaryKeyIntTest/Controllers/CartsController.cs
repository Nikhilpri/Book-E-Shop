using Microsoft.AspNet.Identity;
using PrimaryKeyIntTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PrimaryKeyIntTest.Controllers
{
    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Carts

        public ActionResult ViewCart()
        {
            int usId = 100016; //int.Parse(User.Identity.GetUserId());
            var carts = db.Carts.Include(c => c.Book).Where(c => c.UserId == usId); 
            return View(carts.ToList());
        }




        [Authorize]
        public ActionResult AddCart(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var list = new List<Book>();
                Book book = db.Books.Find(id);
                Cart cart = new Cart();
                cart.UserId = int.Parse(User.Identity.GetUserId());
                cart.OrderStatus = "Processing...";
                //cart.Book = book;
                cart.BookId = book.BookId;
                cart.DueDate = DateTime.Now.AddDays(15);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(cart);
            }
            
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[Bind(Include = "Id,BookName,BookCode,BookDescription,Author,BookCategory,BookType,Option,Rate,Discounts,TimeStamp,Archived")]*/

        //[Bind(Include = "Id,UserId,Quantity,OrderType,Address,DueDate,OrderStatus,BookId,Book")]
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult AddCart([Bind(Include = "Id,UserId,Quantity,OrderType,Address,DueDate,OrderStatus,BookId")] Cart cart)
        {
            if (ModelState.IsValid)
            {                
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("CustomerIndex","Home");
            }
            return View(cart);
        }

    }
}