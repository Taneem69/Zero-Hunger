using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class EmployeeService
    {
        EmployeeRepo repo;
        IMapper mapper;

        public EmployeeService(EmployeeRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public bool Create(EmployeeModel model)
        {
            var data = mapper.Map<Employee>(model);

            return repo.Create(data);
        }

        public List<Employee> Read()
        {
            return repo.Read();
        }

        public bool Update(EmployeeModel model)
        {
            var data = mapper.Map<Employee>(model);

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
