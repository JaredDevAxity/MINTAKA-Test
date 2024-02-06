// <summary>
// <copyright file="TestsFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Facade.Tests.Impl
{
    /// <summary>
    /// Class TestsFacade.
    /// </summary>
    public class TestsFacade : ITestsFacade
    {
        private readonly ITestsService testsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsFacade"/> class.
        /// </summary>
        /// <param name="testsService">Interface TestsService.</param>
        public TestsFacade(ITestsService testsService) =>
            this.testsService = testsService ?? throw new ArgumentNullException(nameof(testsService));

        /// <inheritdoc/>
        public async Task<IEnumerable<TestDto>> GetAllAsync()
            => await this.testsService.GetAllAsync();

        /// <inheritdoc/>
        public async Task<TestDto> GetByIdAsync(int id)
            => await this.testsService.GetByIdAsync(id);

        /// <inheritdoc/>
        public async Task<TestDto> InsertAsync(string user, CreateTestDto testRequest)
            => await this.testsService.InsertAsync(user, testRequest);

        /// <inheritdoc/>
        public async Task<TestDto> UpdateAsync(
            int id, string user, UpdateTestDto testRequest)
            => await this.testsService.UpdateAsync(id, user, testRequest);

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
            => await this.testsService.DeleteAsync(id);
    }
}