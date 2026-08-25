using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DistributionRepo
    {
        ZeroHungerDbContext db;

        public DistributionRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public bool Create(Distribution d)
        {
            db.Distributions.Add(d);
            return db.SaveChanges() > 0;
        }

        public List<Distribution> Read()
        {
            List<Distribution> data = (from d in db.Distributions.Include(r => r.Request).Include(e => e.EIdNavigation) select d).ToList();

            return data;
        }

        public List<Distribution> GetById(int id)
        {
            List<Distribution> data =(from d in db.Distributions.Include(r => r.Request).Include(e => e.EIdNavigation) where d.DId == id select d).ToList();

            return data;
        }

        public bool Delete(int id)
        {
            var data = db.Distributions.Find(id);

            if (data == null)
            {
                return false;
            }

            db.Distributions.Remove(data);

            return db.SaveChanges() > 0;
        }

        public List<Distribution> GetWithEmployeeName()
        {
            List<Distribution> data = (from d in db.Distributions.Include(e => e.EIdNavigation) select d).ToList();

            return data;
        }

    }
}
