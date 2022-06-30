using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivitiesBusiness : IActivitiesBusiness
    { 
        
        public readonly IUnitOfWork _unitOfWork;
        public ActivitiesBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Activity> GetById(int Id)
        {
            var e = await _unitOfWork.ActivitiesRepository.GetById(Id);
            return e;
        }

        public async Task<Activity> Update(Activity model, UpdateActivityDto activity)
        {

            model.Name = activity.Name;
            model.Content = activity.Content;
            var result = await _unitOfWork.ActivitiesRepository.Update(model);
            if (!result)
            {
                return null;

            }
            return model;
        }

        public Task Insert()
        {
            throw new NotImplementedException();
        }

        
    }
}
