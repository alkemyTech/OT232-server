﻿using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICommentsBusiness
    {
        Task<Response<bool>> Insert(List<InsertCommentDto> commentDto);
        Task GetAll();
        Task GetById(int Id);
        Task Delete(int Id);
        Task Update();
    }
}