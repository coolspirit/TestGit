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
    public class DrinksController : Controller
    {
        private RestaurantContext context = new RestaurantContext();

        //
        // GET: /Drinks/

        public ViewResult Index()
        {
            return View(context.Drinks.ToList());
        }
        //
        // GET: /Drinks/Details/5

        public ViewResult Details(int id)
        {
            Drink drink = context.Drinks.Single(x => x.DrinkId == id);
            return View(drink);
        }

        //
        // GET: /Drinks/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Drinks/Create

        [HttpPost]
        public ActionResult Create(Drink drink)
        {
            if (ModelState.IsValid)
            {
                context.Drinks.Add(drink);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(drink);
        }
        
        //
        // GET: /Drinks/Edit/5
 
        public ActionResult Edit(int id)
        {
            Drink drink = context.Drinks.Single(x => x.DrinkId == id);
            return View(drink);
        }

        //
        // POST: /Drinks/Edit/5

        [HttpPost]
        public ActionResult Edit(Drink drink)
        {
            if (ModelState.IsValid)
            {
                context.Entry(drink).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        //
        // GET: /Drinks/Delete/5
 
        public ActionResult Delete(int id)
        {
            Drink drink = context.Drinks.Single(x => x.DrinkId == id);
            return View(drink);
        }

        //
        // POST: /Drinks/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Drink drink = context.Drinks.Single(x => x.DrinkId == id);
            context.Drinks.Remove(drink);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}