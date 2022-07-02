using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OngProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngDbContext _context;
        public IGenericRepository<News> _newsRepository;
        public IGenericRepository<User> _usersRepository;
        public IGenericRepository<Category> _categoriesRepository;
        public IGenericRepository<Activity> _activitiesRepository;
        public IGenericRepository<Comment> _commentsRepository;
        public IGenericRepository<Contact> _contactsRepository;
        public IGenericRepository<Member> _membersRepository;
        public IGenericRepository<Organization> _organizationsRepository;
        public IGenericRepository<Testimonial> _testimonialsRepository;
        public IGenericRepository<Slide> _slidesRepository;
        public IGenericRepository<Roles> _rolesRepository;

        public UnitOfWork(OngDbContext context)
        {
            _context = context;
        }
        
        public IGenericRepository<News> NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new GenericRepository<News>(_context);

                }
                return _newsRepository;
            }
        }

        public IGenericRepository<User> UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new GenericRepository<User>(_context);

                }
                return _usersRepository;
            }
        }

        public IGenericRepository<Activity> ActivitiesRepository
        {
            get
            {
                if (_activitiesRepository == null)
                {
                    _activitiesRepository = new GenericRepository<Activity>(_context);

                }
                return _activitiesRepository;
            }
        }
        
        public IGenericRepository<Category> CategoriesRepository
        {
            get
            {
                if (_categoriesRepository == null)
                {
                    _categoriesRepository = new GenericRepository<Category>(_context);

                }
                return _categoriesRepository;
            }
        }

        public IGenericRepository<Comment> CommentRepository
        {
            get
            {
                if (_commentsRepository == null)
                {
                    _commentsRepository = new GenericRepository<Comment>(_context);

                }
                return _commentsRepository;
            }
        }

        public IGenericRepository<Contact> ContactsRepository
        {
            get
            {
                if (_contactsRepository == null)
                {
                    _contactsRepository = new GenericRepository<Contact>(_context);

                }
                return _contactsRepository;
            }
        }


        public IGenericRepository<Member> MemberRepository
        {
            get
            {
                if (_membersRepository == null)
                {
                    _membersRepository = new GenericRepository<Member>(_context);

                }
                return _membersRepository;
            }
        }

        public IGenericRepository<Organization> OrganizationsRepository
        {
            get
            {
                if (_organizationsRepository == null)
                {
                    _organizationsRepository = new GenericRepository<Organization>(_context);

                }
                return _organizationsRepository;
            }
        }

        public IGenericRepository<Testimonial> TestimonialRepository
        {
            get
            {
                if (_testimonialsRepository == null)
                {
                    _testimonialsRepository = new GenericRepository<Testimonial>(_context);

                }
                return _testimonialsRepository;
            }
        }

        public IGenericRepository<Slide> SlideRepository
        {
            get
            {
                if (_slidesRepository == null)
                {
                    _slidesRepository = new GenericRepository<Slide>(_context);

                }
                return _slidesRepository;
            }
        }

        public IGenericRepository<Roles> RolesRepository
        {
            get
            {
                if (_rolesRepository == null)
                {
                    _rolesRepository = new GenericRepository<Roles>(_context);

                }
                return _rolesRepository;
            }
        }


    }
}


