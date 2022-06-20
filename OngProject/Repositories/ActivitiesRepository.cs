using OngProject.DataAccess;


namespace OngProject.Repositories
{
    public class ActivitiesRepository : GenericRepository<Activity>
    {
        private readonly DbContext _context;

        public ActivitiesRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}