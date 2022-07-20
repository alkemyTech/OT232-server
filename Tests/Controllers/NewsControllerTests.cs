using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OngProject.Controllers;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helper;

namespace Tests
{
    [TestClass]
    public class NewsControllerTests : BaseTest
    {
        public INewsBusiness _newsbusinnes;

        [TestInitialize]
        public void Init()
        {
            _newsbusinnes = BuildNewsBusiness();
        }
        [TestMethod]
        [DataRow(3)]
        public async Task GetAll_SouldReturnANewsDTOListAllPage(int page)
        {
            var response = await _newsbusinnes.GetAll(page);
            Assert.IsInstanceOfType(response.Data, typeof(PagedData<List<NewsDto>>));
        }

        [TestMethod]
        [DataRow(2)]
        public async Task GetByID_souldReturnANewsDTO(int id)
        {
            var respose = await _newsbusinnes.GetById(id);
            Assert.IsTrue(respose.Succeeded);
        }

        [TestMethod]
        public async Task InsertNews_ShouldReturnSuccess()
        {
            var news = new InsertNewsDto { Name = "prueba", Image = "prueba.jpg", Description = "Texto Prueba" };

            var response = await _newsbusinnes.Insert(news);

            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task InsertNews_ShouldThrowNullException()
        {
            //Arrange
            InsertNewsDto news;
            news = null;

            //Act
            var response = await _newsbusinnes.Insert(news);

            // Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        public async Task Deletenews_ShouldReturnSuccessResponse()
        {
            var news = new InsertNewsDto { Name = "prueba", Description = "texto prueba", Image = "prueba.jpg" };

            await _newsbusinnes.Insert(news);
            var deleteResponse = await _newsbusinnes.Delete(1);

            Assert.IsTrue(deleteResponse.Data);
        }

        [TestMethod]
        public async Task Deletenews_ShouldReturnErrorResponse()
        {
            var news = new InsertNewsDto { Name = "prueba", Description = "texto prueba", Image = "prueba.jpg" };

            await _newsbusinnes.Insert(news);
            var deleteResponse = await _newsbusinnes.Delete(20);

            Assert.IsFalse(deleteResponse.Data);
        }
        [TestMethod]
        public async Task UpdateMember_ReturnShouldSuccesResponse()
        {
            //Arrange
            var news = new InsertNewsDto { Name = "prueba", Description = "texto prueba", Image = "prueba.jpg" };
            await _newsbusinnes.Insert(news);

            var NewsUpdate = new UpdateToNewsDto
            {
                Name = "prueba",
                Image = "prueba.jpg",
                Description = "Texto de prueba",
            };

            //Act
            var updateResponse = await _newsbusinnes.Update(NewsUpdate, 1);

            //Assert
            Assert.IsTrue(updateResponse.Data);

        }
        [TestMethod]
        public async Task UpdateNewsReturnShouldErrorResponse()
        {
            //Arrange
            var news = new InsertNewsDto { Name = "prueba", Description = "texto prueba", Image = "prueba.jpg" };
            await _newsbusinnes.Insert(news);

            var newsUpdate = new UpdateToNewsDto
            {
                Name = "prueba",
                Image = "prueba.jpg",
                Description = "Texto de prueba",
            };

            //Act
            var updateResponse = await _newsbusinnes.Update(newsUpdate, 999);

            //Assert
            Assert.IsFalse(updateResponse.Data);
        }
    }
}
