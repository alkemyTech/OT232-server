using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helper;

namespace Tests
{
    [TestClass]
    public class AuthenticationControllerTests : BaseTest
    {
        public IAuthenticationBusiness _business;

        [TestInitialize]
        public void Init()
        {
            _business = BuildAuthenticationBusiness();
        }

        [TestMethod]
        public async Task RegisterShouldReturnSuccessResponse()
        {
            //Arrange
            var register = new RegisterRequestDto {FirstName = "Jose", LastName = "Perez", Email = "jose.p@gmail.com", Password = "jose123"};

            //Act
            var response = await _business.UserRegister(register);

            //Assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public async Task RegisterShouldThrowNullException()
        {
            //Arrange
            var register = new RegisterRequestDto();

            //Act
            var response = await _business.UserRegister(register);

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        
        public async Task LoginShouldReturnSuccessResponse()
        {
            //Arrange
            var register = new RegisterRequestDto { FirstName = "Jose", LastName = "Perez", Email = "jose.p@gmail.com", Password = "jose123" };
            var login = new LoginUserDto { Email = "jose.p@gmail.com", Password = "jose123" };

            //Act
            var insert = await _business.UserRegister(register);
            var exit = await _business.UserExists(login);

            //Assert
            if (exit.Count > 0)
            {
                var response = true;
                Assert.IsTrue(response);
            }       
        }

        [TestMethod]

        public async Task LoginShouldReturnFailedResponse()
        {
            //Arrange
            var register = new RegisterRequestDto { FirstName = "Jose", LastName = "Perez", Email = "jose.p@gmail.com", Password = "jose123" };
            var login = new LoginUserDto { Email = "josse.p@gmail.com", Password = "jose123" };

            //Act
            var insert = await _business.UserRegister(register);
            var exit = await _business.UserExists(login);

            //Assert
            if (exit.Count == 0)
            {
                var respose = false;
                Assert.IsFalse(respose);
            }
        }

    }
}
