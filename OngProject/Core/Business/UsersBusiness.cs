using OngProject.Core.Interfaces;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly UnitOfWork _UoW;

        public UsersBusiness(UnitOfWork UoW)
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
