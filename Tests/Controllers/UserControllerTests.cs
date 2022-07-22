using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helper;

namespace Tests.Controllers
{
    [TestClass]
    public class UserControllerTests : BaseTest
    {
        public IUsersBusiness _business;

        [TestInitialize]
        public void Init()
        {
            _business = BuildUsersBusiness();
        }

        [TestMethod]
        public async Task GetAll_SouldReturnAUsersDTOList()
        {
            //Arrange       
            var usersDtoList = new RegisterRequestDto { FirstName = "Marita", LastName = "Gomez", Email = "marita_Gomez2022@user.com" };
            //contactsDtoList.Add(new RegisterRequestDto { FirstName = "Marita", LastName = "Gomez", Email = "marita_Gomez2022@user.com" });
            var response = await _business.Insert(usersDtoList);


            //Act
            var contacts = await _business.GetAll();

            //Assert
            Assert.IsTrue(contacts.Data.Count > 0);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnSuccessResponse()
        {
            //Arrange
            var user = new RegisterRequestDto { FirstName = "Marita", LastName = "Gomez", Email = "marita_Gomez2022@user.com", RoleID = 1, Password = "hola" };

            //Act
            await _business.Insert(user);
            var deleteResponse = await _business.Delete(1);

            //Assert
            Assert.IsTrue(deleteResponse.Data);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnErrorResponse()
        {
            //Arrange
            var user = new RegisterRequestDto { FirstName = "Marita", LastName = "Gomez", Email = "marita_Gomez2022@user.com" };

            //Act
            var insertResponse = await _business.Insert(user);
            var deleteResponse = await _business.Delete(300);

            //Assert
            Assert.IsFalse(deleteResponse.Data);
        }

    }
}
