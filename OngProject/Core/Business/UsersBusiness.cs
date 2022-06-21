using OngProject.Core.Interfaces;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUnitOfWork _UoW;

        public UsersBusiness(IUnitOfWork UoW)
        {
            _UoW = UoW;
        }


        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Task> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert()
        {
            throw new System.NotImplementedException();
        }

        public Task Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
