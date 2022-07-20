using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helper;

namespace Tests.Controllers
{
    [TestClass]
    public class MembersControllersTests : BaseTest
    {
        public IMembersBusiness _membersBusiness;

        [TestInitialize]
        public void Init()
        {
            _membersBusiness = BuildMembersBusiness();
        }

        [TestMethod]
        public async Task InsertMembers_ShouldReturnSuccessResponse()
        {
            var members = new List<InsertMemberDto>();
            members.Add(new InsertMemberDto { Name = "Jessica Gimenez", Image = "jessica.jpg", Description = "Colaborardor de proyecto Ong", FacebookUrl = "www.facebook.com/jessic.gimen", InstagramUrl = "Instagram/Jessica-Gimenez", LinkedinUrl = "www.linkedin.com/in/jessica-gimenez-609593193/" });

            var response = await _membersBusiness.Insert(members);

            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task InsertMembers_ShouldThrowNullException()
        {
            //Arrange
            var members = new List<InsertMemberDto>();
            members.Add(null);

            //Act
            var response = await _membersBusiness.Insert(members);

            //Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        public async Task DeleteMembers_ShouldReturnSuccessResponse()
        {
            var members = new List<InsertMemberDto>();
            members.Add(new InsertMemberDto { Name = "Jessica Gimenez", Image = "jessica.jpg", Description = "Colaborardor de proyecto Ong", FacebookUrl = "www.facebook.com/jessic.gimen", InstagramUrl = "Instagram/Jessica-Gimenez", LinkedinUrl = "www.linkedin.com/in/jessica-gimenez-609593193/" });

            await _membersBusiness.Insert(members);
            var deleteResponse = await _membersBusiness.Delete(1);

            Assert.IsTrue(deleteResponse.Data);
        }

        [TestMethod]
        public async Task DeleteMembers_ShouldReturnErrorResponse()
        {
            var members = new List<InsertMemberDto>();
            members.Add(new InsertMemberDto { Name = "Jessica Gimenez", Image = "jessica.jpg", Description = "Colaborardor de proyecto Ong", FacebookUrl = "www.facebook.com/jessic.gimen", InstagramUrl = "Instagram/Jessica-Gimenez", LinkedinUrl = "www.linkedin.com/in/jessica-gimenez-609593193/" });

            await _membersBusiness.Insert(members);
            var deleteResponse = await _membersBusiness.Delete(20);

            Assert.IsFalse(deleteResponse.Data);
        }
        [TestMethod]
        public async Task UpdateMember_ReturnShouldSuccesResponse()
        {
            //Arrange
            var members = new List<InsertMemberDto>();
            members.Add(new InsertMemberDto { Name = "Jessica Gimenez", Image = "jessica.jpg", Description = "Colaborardor de proyecto Ong", FacebookUrl = "www.facebook.com/jessic.gimen", InstagramUrl = "Instagram/Jessica-Gimenez", LinkedinUrl = "www.linkedin.com/in/jessica-gimenez-609593193/" });
            await _membersBusiness.Insert(members);

            var memberUpdate = new UpdateMemberDto
            {
                Name = "Paola Aguilar",
                Image = "paola.jpg",
                Description = "Colaborardor de proyecto Ong",
                FacebookUrl = "www.facebook.com/paol.aguil",
                InstagramUrl = "Instagram/Paola-Aguilar",
                LinkedinUrl = "www.linkedin.com/in/Paola-Aguilar-609593193/"
            };

            //Act
            var updateResponse = await _membersBusiness.Update(memberUpdate, 1);

            //Assert
            Assert.IsTrue(updateResponse.Data);
           
        }
        [TestMethod]
        public async Task UpdateMember_ReturnShouldErrorResponse()
        {
            //Arrange
            var members = new List<InsertMemberDto>();
            members.Add(new InsertMemberDto { Name = "Jessica Gimenez", Image = "jessica.jpg", Description = "Colaborardor de proyecto Ong", FacebookUrl = "www.facebook.com/jessic.gimen", InstagramUrl = "Instagram/Jessica-Gimenez", LinkedinUrl = "www.linkedin.com/in/jessica-gimenez-609593193/" });
            await _membersBusiness.Insert(members);

            var memberUpdate = new UpdateMemberDto
            {
                Name = "Paola Aguilar",
                Image = "paola.jpg",
                Description = "Colaborardor de proyecto Ong",
                FacebookUrl = "www.facebook.com/paol.aguil",
                InstagramUrl = "Instagram/Paola-Aguilar",
                LinkedinUrl = "www.linkedin.com/in/Paola-Aguilar-609593193/"
            };

            //Act
            var updateResponse = await _membersBusiness.Update(memberUpdate, 999);

            //Assert
            Assert.IsFalse(updateResponse.Data);
        }
        [TestMethod]
        public async Task GetAllPagedDataMemberDto_ReturnShouldResponseSuccess()
        {
            int numPage = 1;
            var response = await _membersBusiness.GetAll(numPage);
            Assert.IsInstanceOfType(response.Data, typeof(PagedData<List<MemberDto>>));//Is.Typeof<response>());
        }
    }
   
}
