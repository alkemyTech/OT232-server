using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        private readonly DbContext _context;
        public NewsRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
