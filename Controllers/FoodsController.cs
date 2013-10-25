using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{   
    public class FoodsController : Controller
    {
        private RestaurantContext context = new RestaurantContext();

        //
        // GET: /Foods/

        public ViewResult Index()
        {
            return View(context.Foods.ToList());
        }

        //
        // GET: /Foods/Details/5

        public ViewResult Details(int id)
        {
            Food food = context.Foods.Single(x => x.FoodId == id);
            return View(food);
        }

        //
        // GET: /Foods/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Foods/Create

        [HttpPost]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                context.Foods.Add(food);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(food);
        }
        
        //
        // GET: /Foods/Edit/5
 
        public ActionResult Edit(int id)
        {
            Food food = context.Foods.Single(x => x.FoodId == id);
            return View(food);
        }

        //
        // POST: /Foods/Edit/5

        [HttpPost]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                context.Entry(food).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food);
        }

        //
        // GET: /Foods/Delete/5
 
        public ActionResult Delete(int id)
        {
            Food food = context.Foods.Single(x => x.FoodId == id);
            return View(food);
        }

        //
        // POST: /Foods/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = context.Foods.Single(x => x.FoodId == id);
            context.Foods.Remove(food);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}