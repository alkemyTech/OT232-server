using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<News> Delete(int id)
        {
            var model = await _unitOfWork.NewsRepository.Delete(id);

            return model;
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int Id)
        {
            return _unitOfWork.NewsRepository.GetById(Id);
        }

        public Task Insert()
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
