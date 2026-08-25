using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RestaurantService
    {
        RestaurantRepo repo;
        IMapper mapper;

        public RestaurantService(RestaurantRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public bool Create(RestaurantModel model)
        {
            var data = mapper.Map<Restaurant>(model);

            return repo.Create(data);
        }

        public List<Restaurant> Read()
        {
            return repo.Read();
        }

        public bool Update(RestaurantModel model)
        {
            var data = mapper.Map<Restaurant>(model);

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
