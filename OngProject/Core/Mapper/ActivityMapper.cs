using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public static class ActivityMapper
    {
        public static List<Activity> ToActivityList(List<InsertActivityDto> activityDtos)
        {
            List<Activity> activity = new();

            if (activityDtos != null)
            {
                foreach (var m in activityDtos)
                {
                    activity.Add
                    (
                        new Activity
                        {
                            Name = m.Name,
                            Content = m.Content,
                            Image = m.Image
                        }
                    );
                }
                return activity;
            }
            return null;
        }

        public static List<ActivitiesDto> ToActivitiesDtoList(List<Activity> activities)
        {
            List<ActivitiesDto> activityDtos = new();

            if (activities != null)
            {
                foreach (var m in activities)
                {
                    activityDtos.Add
                    (
                        new ActivitiesDto
                        {
                            Name = m.Name,
                            Content = m.Content,
                            Image = m.Image,
                        }
                    );
                }
                return activityDtos;
            }
            return null;
        }
        
        public static Activity UpdateToActivity(UpdateActivityDto activityDto, Activity model)
        {
            if (model != null)
            {
                model.Name = activityDto.Name;
                model.Content = activityDto.Content;
                model.Image = activityDto.Image;
                return model;
            }
            return null;
        }
    }
}