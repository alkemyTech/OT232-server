using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivitiesBusiness : IActivitiesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActivitiesBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>(await _unitOfWork.ActivitiesRepository.Delete(Id));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFoundOrDeleted;
            }

            return response;
        }

        public async Task<Response<List<ActivitiesDto>>> GetAll()
        {
            var response = new Response<List<ActivitiesDto>>(ActivityMapper.ToActivitiesDtoList(await _unitOfWork.ActivitiesRepository.GetAll()));

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public async Task<Response<bool>> Insert(List<InsertActivityDto> activityDtos)
        {
            var response = new Response<bool>(await _unitOfWork.ActivitiesRepository.InsertRange(ActivityMapper.ToActivityList(activityDtos)));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public async Task<Response<bool>> Update(int Id, UpdateActivityDto activityDto)
        {
            var response = new Response<bool>(false);
            var model = await _unitOfWork.ActivitiesRepository.GetById(Id);

            if (model == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.NotFound;
                return response;
            }

            response.Data = await _unitOfWork.ActivitiesRepository.Update(ActivityMapper.UpdateToActivity(activityDto, model));
            return response;
        }
    }
}