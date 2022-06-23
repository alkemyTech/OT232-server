using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class RolesBusiness : IRolesBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public RolesBusiness(UnitOfWork unitOfWork)
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

        public Task GetById(int Id)
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
