// <summary>
// <copyright file="[%= name %]ServiceTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Test.Services.[%= name %]
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using [%= company %].[%= name %].DataAccess.DAO.[%= name %];
    using [%= company %].[%= name %].Entities.Context;
    using [%= company %].[%= name %].Services.Mapping;
    using [%= company %].[%= name %].Services.[%= name %];
    using [%= company %].[%= name %].Services.[%= name %].Impl;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    /// <summary>
    /// Class [%= name %]ServiceTest.
    /// </summary>
    [TestFixture]
    public class [%= name %]ServiceTest : BaseTest
    {
        private I[%= name %]Service modelServices;

        private IMapper mapper;

        private I[%= name %]Dao modelDao;

        private DatabaseContext context;

        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            this.mapper = mapperConfiguration.CreateMapper();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Temporal")
                .Options;

            this.context = new DatabaseContext(options);
            this.context.Cat[%= name %].AddRange(this.GetAll[%= name %]s());
            this.context.SaveChanges();

            this.modelDao = new [%= name %]Dao(this.context);
            this.modelServices = new [%= name %]Service(this.mapper, this.modelDao);
        }

        /// <summary>
        /// Method to verify Get All [%= name %]s.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateGetAll[%= name %]s()
        {
            var result = await this.modelServices.GetAll[%= name %]Async();

            Assert.True(result != null);
            Assert.True(result.Any());
        }

        /// <summary>
        /// Method to validate get model by id.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateSpecific[%= name %]s()
        {
            var result = await this.modelServices.Get[%= name %]Async(2);

            Assert.True(result != null);
            Assert.True(result.FirstName == "Jorge");
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task Insert[%= name %]()
        {
            // Arrange
            var model = this.Get[%= name %]Dto();

            // Act
            var result = await this.modelServices.Insert[%= name %](model);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}
