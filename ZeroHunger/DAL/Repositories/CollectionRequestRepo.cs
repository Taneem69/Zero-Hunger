using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CollectionRequestRepo
    {
        ZeroHungerDbContext db;

        public CollectionRequestRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public bool Create(CollectionRequest r)
        {
            db.CollectionRequests.Add(r);
            return db.SaveChanges() > 0;
        }

        public List<CollectionRequest> Read()
        {
            List<CollectionRequest> data = (from cr in db.CollectionRequests.Include(r => r.RIdNavigation).Include(e => e.EIdNavigation) select cr).ToList();

            return data;
        }

        public List<CollectionRequest> GetById(int id)
        {
            List<CollectionRequest> data = (from cr in db.CollectionRequests.Include(r => r.RIdNavigation).Include(e => e.EIdNavigation) where cr.RequestId == id select cr).ToList();

            return data;
        }

        public bool Update(CollectionRequest r)
        {
            var data = db.CollectionRequests.Find(r.RequestId);

            if (data == null)
            {
                return false;
            }

            data.RId = r.RId;
            data.EId = r.EId;
            data.FoodDescription = r.FoodDescription;
            data.Quantity = r.Quantity;
            data.PreserveUntil = r.PreserveUntil;
            data.Status = r.Status;
            data.CollectionTime = r.CollectionTime;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.CollectionRequests.Find(id);

            if (data == null)
            {
                return false;
            }

            db.CollectionRequests.Remove(data);

            return db.SaveChanges() > 0;
        }


        public List<CollectionRequest> GetWithRestaurantName()
        {
            List<CollectionRequest> data =(from cr in db.CollectionRequests.Include(r => r.RIdNavigation) select cr).ToList();

            return data;
        }


        public List<CollectionRequest> GetWithEmployeeName()
        {
            List<CollectionRequest> data =(from cr in db.CollectionRequests.Include(e => e.EIdNavigation) select cr).ToList();

            return data;
        }
    }
}
