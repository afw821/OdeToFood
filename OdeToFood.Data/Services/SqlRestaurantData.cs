using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //not optimistic concurrency (last user wins)
            //var r = Get(restaurant.Id);
            //r.Name = "";
            //db.SaveChanges();

            //optimistic concurrency
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
