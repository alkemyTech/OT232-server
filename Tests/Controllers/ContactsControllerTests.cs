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
    public class ContactsControllerTests : BaseTest
    {
        public IContactsBusiness _business;

        [TestInitialize]
        public void Init()
        {
            _business = BuildContactBussines();
        }

        [TestMethod]
        public async Task GetAll_SouldReturnAContactsDTOList()
        {
            //Arrange       
            var contactsDtoList = new List<InsertContactDto>();
            contactsDtoList.Add(new InsertContactDto { Name = "Patricio", Email = "Patricioorce@gmail.com", Phone = "123456789", Message = "Hello World" });
            contactsDtoList.Add(new InsertContactDto { Name = "Carlos", Email = "CarlosGroso@gmail.com", Phone = "987654321", Message = "Good Bye World" });
            contactsDtoList.Add(new InsertContactDto { Name = "Estela", Email = "EstelaGomez@gmail.com", Phone = "5467328910", Message = "Hello Again World" });
            var response = await _business.Insert(contactsDtoList);


            //Act
            var contacts = await _business.GetAll();

            //Assert
            Assert.IsTrue(contacts.Data.Count > 0);
            Assert.IsInstanceOfType(contacts, typeof(Response<List<ContactsDto>>));
            Assert.AreEqual(contactsDtoList.Count, contacts.Data.Count);
        }

        [TestMethod]
        public async Task Insert_ShouldReturnSuccessResponse()
        {
            //Arrange
            var contact = new List<InsertContactDto>();
            contact.Add(new InsertContactDto { Name = "Patricio", Email = "Patricioorce@gmail.com", Phone = "123456789", Message = "Hello World" });
            
            //Act
            var response = await _business.Insert(contact);

            //Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Insert_ShouldThrowNullException()
        {
            //Arrange
            var contact = new List<InsertContactDto>();
            contact.Add(null);

            //Act
            var response = await _business.Insert(contact);

            //Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnSuccessResponse()
        {
            //Arrange
            var contact = new List<InsertContactDto>();
            contact.Add(new InsertContactDto { Name = "Patricio", Email = "Patricioorce@gmail.com", Phone = "123456789", Message = "Hello World" });

            //Act
            await _business.Insert(contact);
            var deleteResponse = await _business.Delete(1);

            //Assert
            Assert.IsTrue(deleteResponse.Data);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnErrorResponse()
        {
            //Arrange
            var contact = new List<InsertContactDto>();
            contact.Add(new InsertContactDto { Name = "Patricio", Email = "Patricioorce@gmail.com", Phone = "123456789", Message = "Hello World" });


            //Act
            var insertResponse = await _business.Insert(contact);
            var deleteResponse = await _business.Delete(3);

            //Assert
            Assert.IsFalse(deleteResponse.Data);
        }
    }
}