﻿using OngProject.Entities;

namespace OngProject.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Activity> ActivitiesRepository { get; }
    }
}
