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
    public class MealsController : Controller
    {
        private RestaurantContext context = new RestaurantContext();

        //
        // GET: /Meals/

        public ViewResult Index()
        {
            return View(context.Meals.Include(meal => meal.Food).Include(meal => meal.Drink).ToList());
        }

        //
        // GET: /Meals/Details/5

        public ViewResult Details(int id)
        {
            Meal meal = context.Meals.Single(x => x.MealId == id);
            return View(meal);
        }

        //
        // GET: /Meals/Create

        public ActionResult Create()
        {
            ViewBag.PossibleFoods = context.Foods;
            ViewBag.PossibleDrinks = context.Drinks;
            return View();
        } 

        //
        // POST: /Meals/Create

        [HttpPost]
        public ActionResult Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                context.Meals.Add(meal);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleFoods = context.Foods;
            ViewBag.PossibleDrinks = context.Drinks;
            return View(meal);
        }
        
        //
        // GET: /Meals/Edit/5
 
        public ActionResult Edit(int id)
        {
            Meal meal = context.Meals.Single(x => x.MealId == id);
            ViewBag.PossibleFoods = context.Foods;
            ViewBag.PossibleDrinks = context.Drinks;
            return View(meal);
        }

        //
        // POST: /Meals/Edit/5

        [HttpPost]
        public ActionResult Edit(Meal meal)
        {
            if (ModelState.IsValid)
            {
                context.Entry(meal).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleFoods = context.Foods;
            ViewBag.PossibleDrinks = context.Drinks;
            return View(meal);
        }

        //
        // GET: /Meals/Delete/5
 
        public ActionResult Delete(int id)
        {
            Meal meal = context.Meals.Single(x => x.MealId == id);
            return View(meal);
        }

        //
        // POST: /Meals/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = context.Meals.Single(x => x.MealId == id);
            context.Meals.Remove(meal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}