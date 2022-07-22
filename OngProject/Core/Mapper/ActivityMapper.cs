using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class ActivityMapper
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
                            Image = m.Image,
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
    }
}