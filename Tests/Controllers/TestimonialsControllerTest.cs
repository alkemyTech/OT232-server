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

namespace Tests.Controllers
{
    [TestClass]
    public class TestimonialsControllerTests : BaseTest
    {
        public ITestimonialsBusiness _business;

        [TestInitialize]
        public void Init()
        {
            _business = BuildTestimonialsBusiness();
        }

        // GET
        [TestMethod]
        [DataRow(1)]
        public async Task GetAllEndpoint_ShouldReturnAllPaged(int page)
        {
            // Arrange
            var listDtos = new List<TestimonialDto>(){
                new TestimonialDto{ Name = @"Nosotros", Image = @"nosotros.jpg",
                    Content = @"Desde 1997 en Somos Mas trabajamos con los chicos y chicas,mamas y papas, abuelos y vecinos del barrio La Cava generando procesos de crecimiento y de insercion social,Uniendo las manos de todas las familias, las que viven en el barrio y las que viven fuera de el, es que podemos pensar,crear y garantizar estos procesos. Somos una asociacion civil sin fines de lucro que se creo en 1998 con la intencion de dar alimento a las familias del barrio. Con el tiempo fuimos involucrandonos con la comunidad y agrandando y mejorar nuestra capacidad de trabajo. Hoy somos un centro comunitario que acompa�a a mas de 700 personas a traves de las areas de : Educacion,deportes,primera infancia,salud,alimentacion y trabajo social.",
                },
                new TestimonialDto{ Name = @"Vision", Image = @"vision.jpg",
                    Content = @"Mejorar la calidad de vida de ni�os y familias en situacion de vulnerabilidad en el barrio La Cava,otorgando un cambio de rumbo en cada individuo a traves de la educacion,salud,trabajo,deporte,responsabilidad y compromiso",
                },
                new TestimonialDto{ Name = @"Mision", Image = @"mision.jpg",
                    Content = @"Trabajar articuladamente con los distintos aspectos de la vida de las familias, generando espacios de desarrollo personal y familiar, brindando herramientas que logren mejorar la calidad de vida a traves de su propio esfuerzo",
                },
                new TestimonialDto{ Name = @"Maria Irola", Image = @"mariaIrola.jpg",
                    Content = @"Presidenta Maria estudio economia y se especializo en economia para el desarrollo. Comenzo como voluntaria en la fundacion y fue quien promovio el crecimiento y la organizacion de la institucion acompa�ando la transformacion de un simple comedor barrial al centro comunitario de atencion integral que es hoy en dia",
                },
                new TestimonialDto{ Name = @"Marita Gomez", Image = @"maritaGomez.jpg",
                    Content = @"Fundadora Marita estudio la carrera de nutricion y se especializo en nutricion infantil. Toda la vida fue voluntaria en distintos espacios en el barrio hasta que decidio abrir un comedor propio.Comenzo trabajando con 5 familias y culmino su trabajo transformando Somos Mas en la organizacion que es hoy",
                }
            };

            var pagedData = new PagedData<List<TestimonialDto>>(listDtos, await _business.CountElements(), page, 10, "Testimonials");
            var responseExpected = new Response<PagedData<List<TestimonialDto>>>(pagedData);

            //  Act
            var response = await _business.GetAll(page);

            // Assert
            Assert.IsInstanceOfType(response, typeof(Response<PagedData<List<TestimonialDto>>>));
            Assert.AreEqual(response.Data.TotalCount, responseExpected.Data.TotalCount);
        }

        // GET
        [TestMethod]
        [DataRow(2)]
        public async Task GetAllEndpoint_ShouldReturnErrorResponse(int page)
        {
            //  Act
            var response = await _business.GetAll(page);

            // Assert
            Assert.IsTrue(response.Data.Items.Count == 0);
            Assert.IsInstanceOfType(response, typeof(Response<PagedData<List<TestimonialDto>>>));
        }

        // POST
        // Insert
        [TestMethod]
        public async Task InsertEndpoint_ShouldReturnSuccessResponse()
        {
            // Arrange
            var testimonialsDtoList = new List<InsertTestimonialDto>();
            testimonialsDtoList.Add(new InsertTestimonialDto { Name = "Prueba1", Content = "El pruebas 1", Image = "elpruebas.png" });

            //  Act
            var insertion = await _business.Insert(testimonialsDtoList);
            var actual = await _business.GetAll();

            // Assert
            Assert.IsTrue(insertion.Data);
            Assert.IsTrue(actual.Data.Items.Count > 0);
            Assert.IsInstanceOfType(actual, typeof(Response<PagedData<List<TestimonialDto>>>));
            Assert.AreEqual(testimonialsDtoList.Count, actual.Data.Items.Count);
        }

        // Insert Bad
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task InsertEndpoint_ShouldReturnErrorResponse()
        {
            // Arrange
            var insertDtoList = new List<InsertTestimonialDto>();
            insertDtoList.Add(null);

            //Act
            var response = await _business.Insert(insertDtoList);

            //Assert
            Assert.IsTrue(response.Data);
        }

        // Delete
        [TestMethod]
        public async Task DeleteEndpoint_ShouldReturnSuccessResponse()
        {
            // Arrange
            var testimonialsDtoList = new List<InsertTestimonialDto>
            {
                new InsertTestimonialDto { Name = "Prueba1", Content = "El pruebas 1", Image = "elpruebas.png" }
            };

            await _business.Insert(testimonialsDtoList);

            // Act
            var response = await _business.Delete(1);

            // Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        public async Task DeleteEndpoint_ShouldReturnErrorResponse()
        {
            // Arrange
            var testimonialsDtoList = new List<InsertTestimonialDto>
            {
                new InsertTestimonialDto { Name = "Prueba1", Content = "El pruebas 1", Image = "elpruebas.png" }
            };

            // Act
            await _business.Insert(testimonialsDtoList);
            var response = await _business.Delete(3);

            // Assert
            Assert.IsFalse(response.Data);
        }

        [TestMethod]
        public async Task UpdateEndpoint_ShouldReturnSuccessResponse()
        {
            // Arrange
            var insertDtoList = new List<InsertTestimonialDto>
            { 
                new InsertTestimonialDto { Name = "Prueba1", Content = "El pruebas 1", Image = "elpruebas.png" } 
            };
            var updateDto = new UpdateTestimonialDto { Name = "Pruebita", Content = "El pruebitas", Image = "testman.pgn" };

            // Act
            await _business.Insert(insertDtoList);
            var response = await _business.Update(updateDto, 1);

            // Assert
            Assert.IsTrue(response.Data);
        }

        [TestMethod]
        public async Task UpdateEndpoint_ShouldReturnErrorResponse()
        {
            // Arrange
            var insertDtoList = new List<InsertTestimonialDto>
            { 
                new InsertTestimonialDto { Name = "Prueba1", Content = "El pruebas 1", Image = "elpruebas.png" } 
            };
            var updateDto = new UpdateTestimonialDto { Name = "Pruebita", Content = "El pruebitas", Image = "testman.pgn" };

            // Act
            await _business.Insert(insertDtoList);
            var response = await _business.Update(updateDto, 20);

            // Assert
            Assert.IsFalse(response.Data);
        }
    }
}