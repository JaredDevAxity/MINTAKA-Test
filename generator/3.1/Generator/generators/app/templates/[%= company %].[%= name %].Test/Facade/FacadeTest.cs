// <summary>
// <copyright file="FacadeTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Test.Facade
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using [%= company %].[%= name %].Dtos.[%= name %];
    using [%= company %].[%= name %].Facade.[%= name %].Impl;
    using [%= company %].[%= name %].Services.[%= name %];

    /// <summary>
    /// Class [%= name %]ServiceTest.
    /// </summary>
    [TestFixture]
    public class FacadeTest : BaseTest
    {
        private [%= name %]Facade modelFacade;

        /// <summary>
        /// The init.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mockServices = new Mock<I[%= name %]Service>();
            var model = this.Get[%= name %]Dto();
            IEnumerable<[%= name %]Dto> list[%= name %] = new List<[%= name %]Dto> { model };

            mockServices
                .Setup(m => m.GetAll[%= name %]Async())
                .Returns(Task.FromResult(list[%= name %]));

            mockServices
                .Setup(m => m.Get[%= name %]Async(It.IsAny<int>()))
                .Returns(Task.FromResult(model));

            mockServices
                .Setup(m => m.Insert[%= name %](It.IsAny<[%= name %]Dto>()))
                .Returns(Task.FromResult(true));

            this.modelFacade = new [%= name %]Facade(mockServices.Object);
        }

        /// <summary>
        /// Test for selecting all models.
        /// </summary>
        /// <returns>nothing.</returns>
        [Test]
        public async Task GetAll[%= name %]AsyncTest()
        {
            // arrange

            // Act
            var response = await this.modelFacade.GetList[%= name %]Active();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// gets the model.
        /// </summary>
        /// <returns>the model with the correct id.</returns>
        [Test]
        public async Task GetList[%= name %]Active()
        {
            // arrange
            var id = 10;

            // Act
            var response = await this.modelFacade.GetList[%= name %]Active(id);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(id, response.Id);
        }

        /// <summary>
        /// Test for inseting models.
        /// </summary>
        /// <returns>the bool if it was inserted.</returns>
        [Test]
        public async Task Insert[%= name %]()
        {
            // Arrange
            var model = new [%= name %]Dto();

            // Act
            var response = await this.modelFacade.Insert[%= name %](model);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response);
        }
    }
}
