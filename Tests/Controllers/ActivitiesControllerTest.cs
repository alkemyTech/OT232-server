using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using Tests.Helper;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Business;
using OngProject.Controllers;
using OngProject.Core.Models;

namespace Tests.Controllers
{
    [TestClass]
    public class ActivitiesControllerTest : BaseTest
    {
        public IActivitiesBusiness _business;

        [TestInitialize]
        public void Init()
        {
            _business = BuildActivitiesBusiness();
        }

        [TestMethod]
       
        public async Task GetAll_SouldReturnAActivitiesDTOList()
        {
            //Arrange

            var activityDto = new List<ActivitiesDto>();
            activityDto.Add(new ActivitiesDto { Name = "Santaigo", Content = "habia una vez truz", Image = "Hola.jpg" });
            activityDto.Add(new ActivitiesDto { Name = "talia", Content = "habia nunca vez truz", Image = "Chau.jpg" });
            activityDto.Add(new ActivitiesDto { Name = "Danuab", Content = "cruz del alba", Image = "cruz.jpg" });
            activityDto.Add(new ActivitiesDto { Name = "aaa", Content = "cruz del ssssalba", Image = "cruz.jpg" });

            //Act
            var activities = await _business.GetAll();

            //Assert
            Assert.IsTrue(activities.Data.Count > 0);
            Assert.IsInstanceOfType(activities, typeof(Response<List<ActivitiesDto>>));
            Assert.AreEqual(activityDto.Count, activities.Data.Count);

        }
        [TestMethod]
        public async Task Insert_ShouldReturnSuccessResponse()
        {
            //Arrange
            var activities = new List<InsertActivityDto>();
            activities.Add(new InsertActivityDto { Name = "Santaigo", Content = "habia una vez truz", Image = "Hola.jpg" });

            //Act
            var response = await _business.Insert(activities);

            //Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Insert_ShouldThrowNullException()
        {
            //Arrange
            var activities = new List<InsertActivityDto>();
            activities.Add(null);

            //Act
            var response = await _business.Insert(activities);

            //Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        public async Task Update_ReturnShouldSuccessResponse()
        {
            //Arrange
            var activityDtos = new List<InsertActivityDto>();
            activityDtos.Add(new InsertActivityDto { Name = "Actividad Nueva", Image = "newactivity.jpg", Content = "Una actividad nueva" });
            await _business.Insert(activityDtos);

            var updateActivity = new UpdateActivityDto
            {
                Name = "Actividad Nueva Nuevita",
                Image = "newactivity.jpg",
                Content = "Una actividad nueva nuevita"
            };

            //Act
            var updateResponse = await _business.Update(1, updateActivity);

            //Assert
            Assert.IsTrue(updateResponse.Data);

        }

        [TestMethod]
        public async Task Update_ReturnShouldErrorResponse()
        {
            //Arrange
            var activityDtos = new List<InsertActivityDto>();
            activityDtos.Add(new InsertActivityDto { Name = "Actividad Nueva", Image = "newactivity.jpg", Content = "Una actividad nueva" });
            await _business.Insert(activityDtos);

            var updateActivity = new UpdateActivityDto
            {
                Name = "Actividad Nueva Nuevita",
                Image = "newactivity.jpg",
                Content = "Una actividad nueva nuevita"
            };

            //Act
            var updateResponse = await _business.Update(999, updateActivity);

            //Assert
            Assert.IsFalse(updateResponse.Data);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnSuccessResponse()
        {
            //Arrange
            var activities = new List<InsertActivityDto>();
            activities.Add(new InsertActivityDto { Name = "Santaigo", Content = "habia una vez truz", Image = "Hola.jpg" });

            //Act
            await _business.Insert(activities);
            var deleteResponse = await _business.Delete(1);

            //Assert
            Assert.IsTrue(deleteResponse.Succeeded);
        }
        [TestMethod]
        public async Task Delete_ShouldReturnErrorResponse()
        {
            //Arrange
            var activities = new List<InsertActivityDto>();
            activities.Add(new InsertActivityDto { Name = "Santaigo", Content = "habia una vez truz", Image = "Hola.jpg" });


            //Act
             await _business.Insert(activities);
            var deleteResponse = await _business.Delete(100);

            //Assert
            Assert.IsFalse(deleteResponse.Succeeded);
        }
    }
}
