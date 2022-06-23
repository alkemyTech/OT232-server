using OngProject.Core.Interfaces;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlidesBussines : ISlidesBussines
    {

        private readonly IUnitOfWork _unitOfWork;
        public SlidesBussines(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
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
