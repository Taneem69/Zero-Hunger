using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EmployeeRepo
    {
        ZeroHungerDbContext db;

        public EmployeeRepo(ZeroHungerDbContext db)
        {
            this.db = db;
        }

        public bool Create(Employee e)
        {
            db.Employees.Add(e);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Read()
        {
            return db.Employees.ToList();
        }

        public bool Update(Employee e)
        {
            var data = db.Employees.Find(e.EId);

            if (data == null)
            {
                return false;

            }

            data.Ename = e.Ename;
            data.Phone = e.Phone;
            data.Email = e.Email;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = db.Employees.Find(id);

            if (data == null)
            {
                return false;

            }

            db.Employees.Remove(data);

            return db.SaveChanges() > 0;
        }
    }
}
