namespace OngProject.DataAccess
{
    public class UnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
    }
}
