using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class RestaurantContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Restaurant.Models.RestaurantContext>());

        public DbSet<Restaurant.Models.Meal> Meals { get; set; }

        public DbSet<Restaurant.Models.Food> Foods { get; set; }

        public DbSet<Restaurant.Models.Drink> Drinks { get; set; }
    }
}