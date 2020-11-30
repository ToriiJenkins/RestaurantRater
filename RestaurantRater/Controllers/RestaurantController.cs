using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantRater.Models;
using static RestaurantRater.Models.Restaurant;
using System.Data.Entity;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        public RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View (_db.Restaraunts.ToList());
        }

        //GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();

        }

        //POST: RestaurantCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaraunts.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        //GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaraunts.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //POST: Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaraunts.Find(id);
            _db.Restaraunts.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Restaurant/Edit/{id}
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaraunts.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }


        //POST: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit (Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
       
        //GET: Restaurant/Details/{id}
        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaraunts.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

    }

    
}