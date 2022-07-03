using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IMembersBusiness
    {

        public Task<List<MemberDto>> GetAll();

        public Task GetById(int id);

        public Task Insert();

        public Task Update();

        public Task Delete();

    }
}
