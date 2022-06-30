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
        public IGenericRepository<Category> _categoryRepository;
        public IGenericRepository<Activity> _activityRepository;
        public IGenericRepository<Comment> _commentRepository;
        public IGenericRepository<Contact> _contactRepository;
        public IGenericRepository<Member> _memberRepository;
        public IGenericRepository<Organization> _organizationRepository;
        public IGenericRepository<Testimonial> _testimonialRepository;
        public IGenericRepository<Slide> _slideRepository;
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

        public IGenericRepository<Activity> ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = new GenericRepository<Activity>(_context);

                }
                return _activityRepository;
            }
        }
        public IGenericRepository<Category> CategoriesRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_context);

                }
                return _categoryRepository;
            }
        }
        public IGenericRepository<Comment> CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new GenericRepository<Comment>(_context);

                }
                return _commentRepository;
            }
        }
        public IGenericRepository<Contact> ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new GenericRepository<Contact>(_context);

                }
                return _contactRepository;
            }
        }
        public IGenericRepository<Member> MemberRepository
        {
            get
            {
                if (_memberRepository == null)
                {
                    _memberRepository = new GenericRepository<Member>(_context);

                }
                return _memberRepository;
            }
        }
        public IGenericRepository<Organization> OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new GenericRepository<Organization>(_context);

                }
                return _organizationRepository;
            }
        }
        public IGenericRepository<Testimonial> TestimonialRepository
        {
            get
            {
                if (_testimonialRepository == null)
                {
                    _testimonialRepository = new GenericRepository<Testimonial>(_context);

                }
                return _testimonialRepository;
            }
        }
        public IGenericRepository<Slide> SlideRepository
        {
            get
            {
                if (_slideRepository == null)
                {
                    _slideRepository = new GenericRepository<Slide>(_context);

                }
                return _slideRepository;
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


