using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DistributionService
    {
        DistributionRepo repo;
        CollectionRequestRepo requestRepo;
        IMapper mapper;

        public DistributionService(DistributionRepo repo,CollectionRequestRepo requestRepo,IMapper mapper)
        {
            this.repo = repo;
            this.requestRepo = requestRepo;
            this.mapper = mapper;
        }

        public bool Create(DistributionModel model)
        {
            var requestList = requestRepo.GetById(model.RequestId);

            if (requestList.Count == 0)
            {
                return false;
            }

            var request = requestList[0];

            if (request.Status != "Collected" && request.Status != "Distributed")
            {
                return false;
            }

            if (model.QuantityDistributed <= 0)
            {
                return false;
            }

            if (model.QuantityDistributed > request.Quantity)
            {
                return false;
            }

            model.DistributionDate = DateTime.Now;

            var data = mapper.Map<Distribution>(model);

            var result = repo.Create(data);

            if (result)
            {
                request.Status = "Distributed";
                requestRepo.Update(request);
            }

            return result;
        }

        public List<DistributionModel> Read()
        {
            var data = repo.Read();

            return mapper.Map<List<DistributionModel>>(data);
        }

        public List<DistributionModel> GetById(int id)
        {
            var data = repo.GetById(id);

            return mapper.Map<List<DistributionModel>>(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<DistributionEmployeeModel> GetWithEmployeeName()
        {
            var data = repo.GetWithEmployeeName();

            return mapper.Map<List<DistributionEmployeeModel>>(data);
        }
    }
}
