using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationsBusiness
    {

        public Task GetAll();

        public Task GetById(int id);

        public Task Insert();

        public Task Update();

        public Task Delete();

    }
}
