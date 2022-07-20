using Microsoft.EntityFrameworkCore;
using OngProject.Core.Helper;
using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using OngProject.Core.Business;
using Microsoft.Extensions.Configuration;

namespace Tests.Helper
{
    public class BaseTest
    {
        protected static OngDbContext BuildContext()
        {
            var options = new DbContextOptionsBuilder<OngDbContext>().UseInMemoryDatabase(databaseName: "TestOngDb").Options;
            var context = new OngDbContext(options);
            context.Database.EnsureDeleted();

            ActivitiesSeed.Seed(context);
            CategoriesSeed.Seed(context);
            CommentsSeed.Seed(context);
            MembersSeed.Seed(context);
            NewsSeed.Seed(context);
            OrganizationsSeed.Seed(context);
            RolesSeed.Seed(context);
            SlidesSeed.Seed(context);
            TestimonialsSeed.Seed(context);
            UsersSeed.Seed(context);

            context.SaveChanges();

            return context;
        }
        protected static IUnitOfWork BuildUnitOfWork()
        {
            var context = BuildContext();
            return new UnitOfWork(context);
        }
        protected static IUsersBusiness BuildUsersBusiness()
        {
            var unitOfWork = BuildUnitOfWork();
            return new UsersBusiness(unitOfWork);
        }
        protected static IContactsBusiness BuildContactBussines()
        {
            var unitOfWork = BuildUnitOfWork();
            return new ContactsBusiness(unitOfWork);
        }
        protected static ITestimonialsBusiness BuildTestimonialsBusiness()
        {
            var unitOfWork = BuildUnitOfWork();
            return new TestimonialsBusiness(unitOfWork);
        }
        protected static IMembersBusiness BuildMembersBusiness()
        {
            var unitOfWork = BuildUnitOfWork();
            return new MembersBusiness(unitOfWork);
        }

        protected static void BuildSender()
        {
        }
    }
}
