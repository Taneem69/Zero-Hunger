using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RestaurantRepo
    {
        ZeroHungerDbContext db;

        public RestaurantRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public bool Create(Restaurant r)
        {
            db.Restaurants.Add(r);
            return db.SaveChanges() > 0;
        }

        public List<Restaurant> Read()
        {
            return db.Restaurants.ToList();
        }

        public bool Update(Restaurant r)
        {
            var data = db.Restaurants.Find(r.RId);

            if (data == null)
            {
                return false;

            }

            data.Rname = r.Rname;
            data.PersonContacted = r.PersonContacted;
            data.Number = r.Number;
            data.Address = r.Address;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Restaurants.Find(id);

            if (data == null)
            {
                return false;

            }

            db.Restaurants.Remove(data);

            return db.SaveChanges() > 0;
        }
    }
}
