using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceShoppingCartMVC.Models;
using PagedList;

namespace ECommerceShoppingCartMVC.Controllers
{
    public class ProduseController : Controller
    {
        private ShoppingDBEntities db = new ShoppingDBEntities();

        // GET: Produse
        public ActionResult Index(int? page)
        {
            return View(db.Produses.ToList().ToPagedList(page ?? 1, 15));
        }

        // List

        public ActionResult List (int? page)
        {
            var pageNumber = page ?? 1; 
            var onePageOfProducts = db.Produses.OrderBy(x => x.Id).ToPagedList(pageNumber, 15); 
            ViewBag.ListProducts = onePageOfProducts; 
            return View();
        }
        //

        // GET: Produse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produse produse = db.Produses.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        // GET: Produse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nume,Pret")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Produses.Add(produse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produse);
        }

        // GET: Produse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produse produse = db.Produses.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        // POST: Produse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nume,Pret")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produse);
        }

        // GET: Produse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produse produse = db.Produses.Find(id);
            if (produse == null)
            {
                return HttpNotFound();
            }
            return View(produse);
        }

        // POST: Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produse produse = db.Produses.Find(id);
            db.Produses.Remove(produse);
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
