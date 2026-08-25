using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CollectionRequestService
    {
        CollectionRequestRepo repo;
        IMapper mapper;

        public CollectionRequestService(CollectionRequestRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public bool Create(CollectionRequestModel model)
        {
            if (model.Quantity <= 0)
            {
                return false;
            }

            if (model.PreserveUntil <= DateTime.Now)
            {
                return false;
            }

            model.RequestDate = DateTime.Now;
            model.Status = "Pending";

            var data = mapper.Map<CollectionRequest>(model);

            return repo.Create(data);
        }

        public List<CollectionRequestModel> Read()
        {
            var data = repo.Read();

            return mapper.Map<List<CollectionRequestModel>>(data);
        }

        public List<CollectionRequestModel> GetById(int id)
        {
            var data = repo.GetById(id);

            return mapper.Map<List<CollectionRequestModel>>(data);
        }

        public bool Accept(int id)
        {
            var dataList = repo.GetById(id);

            if (dataList.Count == 0)
            {
                return false;
            }

            var data = dataList[0];

            if (data.Status != "Pending")
            {
                return false;
            }

            data.Status = "Accepted";

            return repo.Update(data);
        }

        public bool AssignEmployee(int id, int employeeId)
        {
            var dataList = repo.GetById(id);

            if (dataList.Count == 0)
            {
                return false;
            }

            var data = dataList[0];

            if (data.Status != "Accepted")
            {
                return false;
            }

            data.EId = employeeId;
            data.Status = "Assigned";

            return repo.Update(data);
        }

        public bool Collect(int id)
        {
            var dataList = repo.GetById(id);

            if (dataList.Count == 0)
            {
                return false;
            }

            var data = dataList[0];

            if (data.Status != "Assigned")
            {
                return false;
            }

            data.Status = "Collected";
            data.CollectionTime = DateTime.Now;

            return repo.Update(data);
        }

        public bool Complete(int id)
        {
            var dataList = repo.GetById(id);

            if (dataList.Count == 0)
            {
                return false;
            }

            var data = dataList[0];

            if (data.Status != "Distributed")
            {
                return false;
            }

            data.Status = "Completed";

            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        public List<CollectionRequestRestaurantModel> GetWithRestaurantName()
        {
            var data = repo.GetWithRestaurantName();

            return mapper.Map<List<CollectionRequestRestaurantModel>>(data);
        }


        public List<CollectionRequestEmployeeModel> GetWithEmployeeName()
        {
            var data = repo.GetWithEmployeeName();

            return mapper.Map<List<CollectionRequestEmployeeModel>>(data);
        }
    }
}
