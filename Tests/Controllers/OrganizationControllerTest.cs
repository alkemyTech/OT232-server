using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
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
    public class OrganizationControllerTests : BaseTest
    {
        public IOrganizationsBusiness _business;

        [TestInitialize]
        public void Init()
        {
            _business = BuildOrganizationsBusiness();
        }


        [TestMethod]
        public async Task GetAll_ShouldReturnListOrganizationDto()
        {
            //ARRANGE
            var OrganizationDtoList = new List<InsertOrganizationDto>();
            OrganizationDtoList.Add(new InsertOrganizationDto { Name = "Vanesa", Image = " ", Address = "Boedo 2115 ", Phone = "5837262484",
                Email = "vanesaailin.vh@gmail.com", WelcomeText = "Bienvenidos", AboutUsText = " ", FacebookUrl = " ",InstagramUrl = " ",LinkedinUrl = " ", });
            
            OrganizationDtoList.Add(new InsertOrganizationDto { Name = "Victor", Image = " ", Address = "Cangallo 2222 ", Phone = "4872910485",
                Email = "victorerrador@gmail.com", WelcomeText = "Hola a todos", AboutUsText = " ", FacebookUrl = " ", InstagramUrl = " ", LinkedinUrl = " ",});
            
            OrganizationDtoList.Add(new InsertOrganizationDto { Name = "Ailin", Image = " ", Address = "Arroyo 1212 ", Phone = "1017366583",
                Email = "ailinarrieta@gmail.com", WelcomeText = "Que bueno verte ", AboutUsText = " ", FacebookUrl = " ", InstagramUrl = " ", LinkedinUrl = " ",});
            
            var response = await _business.Insert(OrganizationDtoList);

            //ACT
            var result = await _business.GetAll();
            //int j = 1;


            //ASSERT
            Assert.IsInstanceOfType(result.Data, typeof(List<OrganizationDto>));
        }

        [TestMethod]
        public async Task GetSlides_ShouldReturnListOrganizationDto()
        {
            //ARRANGE
            var response = await _business.GetAll();
            Assert.IsInstanceOfType(response.Data, typeof(List<OrganizationDto>));
        }

        [TestMethod]
        public async Task Update_SouldReturn()
        {
            //ARRANGE
            var organizations = new List<InsertOrganizationDto>();
            organizations.Add(new InsertOrganizationDto {
                Name = "Vanesa",
                Image = " ",
                Address = "Boedo 2115 ",
                Phone = "5837262484",
                Email = "vanesaailin.vh@gmail.com",
                WelcomeText = "Bienvenidos",
                AboutUsText = " ",
                FacebookUrl = " ",
                InstagramUrl = " ",
                LinkedinUrl = " ",
            });
            await _business.Insert(organizations);

            var organizationUpdate = new UpdateOrganizationDto
            {
                Name = "Vanesa Carrera",
                Image = " ",
                Address = "Boedo 211545 ",
                Phone = "5837262484",
                Email = "vanesaailin.vh@gmail.com",
                WelcomeText = "Bienvenidos",
                AboutUsText = " ",
                FacebookUrl = " ",
                InstagramUrl = " ",
                LinkedinUrl = " ",
            };

            //Act
            var updateResponse = await _business.Update(1, organizationUpdate);

            //Assert
            Assert.IsTrue(updateResponse.Data);

        }

        [TestMethod]
        public async Task UpdateOrganization_ReturnShouldErrorResponse()
        {
            //Arrange
            var organizations = new List<InsertOrganizationDto>();
            organizations.Add(new InsertOrganizationDto
            {
                Name = "Vanesa",
                Image = " ",
                Address = "Boedo 2115 ",
                Phone = "5837262484",
                Email = "vanesaailin.vh@gmail.com",
                WelcomeText = "Bienvenidos",
                AboutUsText = " ",
                FacebookUrl = " ",
                InstagramUrl = " ",
                LinkedinUrl = " ",
            });
            await _business.Insert(organizations);

            var organizationUpdate = new UpdateOrganizationDto
            {
                Name = "Vanesa Carrera",
                Image = " ",
                Address = "Boedo 211545 ",
                Phone = "5837262484",
                Email = "vanesaailin.vh@gmail.com",
                WelcomeText = "Bienvenidos",
                AboutUsText = " ",
                FacebookUrl = " ",
                InstagramUrl = " ",
                LinkedinUrl = " ",
            };

            //Act
            var updateResponse = await _business.Update(999, organizationUpdate);

            //Assert
            Assert.IsFalse(updateResponse.Data);
        }
    }    
}
