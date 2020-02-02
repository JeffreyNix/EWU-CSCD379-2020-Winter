﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using SecretSanta.Api.Controllers;
using SecretSanta.Business.Services;
using SecretSanta.Data;
using Microsoft.AspNetCore.Mvc;

namespace SecretSanta.Api.Tests.Controllers
{
    /* reference from Blod Engine
    
    [TestClass]
    public class AuthorControllerTests
    {
        [TestMethod]
        public void Create_AuthorController_Success()
        {
            //Arrange
            var service = new AuthorService();

            //Act
            _ = new AuthorController(service);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_WithoutService_Fails()
        {
            //Arrange
            
            //Act
            _ = new AuthorController(null!);

            //Assert
        }

        [TestMethod]
        public async Task GetById_WithExistingAuthor_Success()
        {
            // Arrange
            var service = new AuthorService();
            Author author = SampleData.CreateInigoMontoya();
            author = await service.InsertAsync(author);

            var controller = new AuthorController(service);

            // Act
            ActionResult<Author> rv = await controller.Get(author.Id!.Value);

            // Assert
            Assert.IsTrue(rv.Result is OkObjectResult);
        }

    }
     */
    [TestClass]
    public abstract class ControllerTestBase<TController, TEntity> where TController : IController<TEntity> where TEntity : EntityBase
    {
        protected abstract IEntityService<TEntity> CreateService();
        protected abstract TController CreateController(IEntityService<TEntity> service);

        protected abstract TEntity CreateEntity();

        [TestMethod]
        public void Create_Controller_Success()
        {
            //Arrange

            //Act
            _ = CreateController(CreateService());

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_WithoutService_Fails()
        {
            //Arrange

            //Act
            _ = CreateController(null!);

            //Assert
        }

        [TestMethod]
        public async Task GetById_WithExistingAuthor_Success()
        {
            // Arrange
            var service = CreateService();
            TEntity entity = CreateEntity();
            entity = await service.InsertAsync(entity);

            var controller = CreateController(service);

            // Act
            ActionResult<TEntity> rv = await controller.Get(entity.Id);

            // Assert
            Assert.IsTrue(rv.Result is OkObjectResult);
        }
    }
}
