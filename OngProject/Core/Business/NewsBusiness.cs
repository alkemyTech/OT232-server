using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public NewsBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
